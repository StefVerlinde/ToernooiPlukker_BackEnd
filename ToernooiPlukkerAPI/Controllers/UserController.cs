using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using ToernooiPlukkerAPI.DTOs;
using ToernooiPlukkerAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToernooiPlukkerAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IToernooiRepository _toernooiRepository;

        public UserController(IUserRepository context, IToernooiRepository ItoernooiRepo)
        {
            _userRepository = context;
            _toernooiRepository = ItoernooiRepo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll().OrderBy(u => u.Naam);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            User user = _userRepository.GetById(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpGet("GetByEmail/{email}")]
        public ActionResult<UserDTO> GetUserByEmail(string email)
        {
            UserDTO userDto = _userRepository.GetByEmail(email);
            if (userDto == null) return NotFound();
            return userDto;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(UserDTO user)
        {
            User userToCreate = new User() {
                Naam = user.Naam,
                Achternaam = user.Achternaam,
                Email = user.Email
                
            };
            _userRepository.Add(userToCreate);
            _userRepository.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = userToCreate.UserId }, userToCreate);
        }

        [HttpPut("{id}")]
        public ActionResult<UserDTO> UpdateUser(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            var usr = _userRepository.Update(user);
            _userRepository.SaveChanges();
            return usr;
        }

        [HttpDelete("{id}")]
        public ActionResult<User> DeleteRecipe(int id)
        {
            User user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userRepository.Delete(user);
            _userRepository.SaveChanges();
            return user;
        }
    }
}
