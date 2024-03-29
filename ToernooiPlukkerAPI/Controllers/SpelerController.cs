﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToernooiPlukkerAPI.DTOs;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class SpelerController: ControllerBase
    {
        private readonly ISpelerRepository _spelerRepository;
        private readonly ITeamRepository _teamRepository;

        public SpelerController(ISpelerRepository context, ITeamRepository teamRepo)
        {
            _spelerRepository = context;
            _teamRepository = teamRepo;
        }

        [HttpGet]
        public IEnumerable<SpelerDTO> GetSpelers()
        {
            return _spelerRepository.GetAll();
        }

        [HttpGet("GetByTeamId/{id}")]
        public IEnumerable<SpelerDTO> GetByTeamId(int id)
        {
            return _spelerRepository.GetByTeamId(id);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<SpelerDTO> GetSpeler(int id)
        {
            SpelerDTO speler = _spelerRepository.GetByIdDto(id);
            if (speler == null) return NotFound();
            return speler;
        }

        [HttpPost("{id}")]
        public ActionResult<Speler> CreateSpeler(int id, SpelerDTO speler)
        {
            Team team = _teamRepository.GetById(id);
            Speler spelerToCreate = new Speler(speler.Naam, speler.Achternaam, speler.Sterkte, speler.Geslacht, speler.Functie, team);
            _spelerRepository.Add(spelerToCreate);
            _spelerRepository.SaveChanges();
            return CreatedAtAction(nameof(GetSpeler), new { id = spelerToCreate.SpelerId }, spelerToCreate);
        }

        [HttpPut("{id}")]
        public ActionResult<Speler> UpdateSpeler(int id, SpelerDTO speler)
        {
            if (id != speler.SpelerId)
            {
                return BadRequest();
            }
            var sp = _spelerRepository.Update(speler);
            _spelerRepository.SaveChanges();
            return sp;
        }

        [HttpDelete("{id}")]
        public ActionResult<Speler> DeleteSpeler(int id)
        {
            Speler speler = _spelerRepository.GetById(id);
            if (speler == null)
            {
                return NotFound();
            }
            _spelerRepository.Delete(speler);
            _spelerRepository.SaveChanges();
            return speler;
        }
    }
}
