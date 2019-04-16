using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToernooiPlukkerAPI.DTOs;
using ToernooiPlukkerAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToernooiPlukkerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository context)
        {
            _userRepository = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll().OrderBy(u => u.Naam);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            User user = _userRepository.GetById(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(UserDTO user)
        {
            User userToCreate = new User() {
                Naam = user.Naam,
                Achternaam = user.Achternaam,
                Email = user.Email,
                Wachtwoord = user.Wachtwoord
            };
            _userRepository.Add(userToCreate);
            _userRepository.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = userToCreate.Id }, userToCreate);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            return NoContent();
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
