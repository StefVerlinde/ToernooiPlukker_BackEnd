using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToernooiPlukkerAPI.DTOs;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ToernooiController: ControllerBase
    {
        private readonly IToernooiRepository _toernooiRepository;
        private readonly IUserRepository _userRepository;

        public ToernooiController(IToernooiRepository context, IUserRepository userRepo)
        {
            _toernooiRepository = context;
            _userRepository = userRepo;
        }

        [HttpGet]
        public IEnumerable<ToernooiDTO> GetToernooien()
        {
            return _toernooiRepository.GetAll().OrderBy(t => t.Datum).Reverse();
        }

        [HttpGet("GetByUserId/{id}")]
        public IEnumerable<ToernooiDTO> GetByUserId(int id)
        {
            return _toernooiRepository.GetByUserId(id).OrderBy(t => t.Datum).Reverse();
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<ToernooiDTO> GetToernooi(int id)
        {
            ToernooiDTO toernooi = _toernooiRepository.GetByIdDto(id);
            if (toernooi == null) return NotFound();
            return toernooi;
        }

        [HttpPost("{id}")]
        public ActionResult<Toernooi> CreateToernooi(int id, ToernooiDTO toernooi)
        {
            User user = _userRepository.GetById(id);
            Toernooi toernooiToCreate = new Toernooi(toernooi.Naam, toernooi.Datum, user);
            _toernooiRepository.Add(toernooiToCreate);
            _toernooiRepository.SaveChanges();
            return CreatedAtAction(nameof(GetToernooi), new { id = toernooiToCreate.ToernooiId }, toernooiToCreate);
        }

        [HttpPut("{id}")]
        public ActionResult<Toernooi> UpdateToernooi(int id, ToernooiDTO toernooi)
        {
            if (id != toernooi.ToernooiId)
            {
                return BadRequest();
            }
            var toer = _toernooiRepository.Update(toernooi);
            _toernooiRepository.SaveChanges();
            return toer;
        }

        [HttpDelete("{id}")]
        public ActionResult<Toernooi> DeleteToernooi(int id)
        {
            Toernooi toernooi = _toernooiRepository.GetById(id);
            if (toernooi == null)
            {
                return NotFound();
            }
            _toernooiRepository.Delete(toernooi);
            _toernooiRepository.SaveChanges();
            return toernooi;
        }
    }
}
