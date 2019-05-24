using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class TeamController: ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository context)
        {
            _teamRepository = context;
        }

        [HttpGet]
        public IEnumerable<TeamDTO> GetTeams()
        {
            return _teamRepository.GetAll();
        }

        [HttpGet("GetByToernooiId/{id}")]
        public IEnumerable<TeamDTO> GetByToernooiId(int id)
        {
            return _teamRepository.GetByToernooiId(id);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<TeamDTO> GetTeam(int id)
        {
            TeamDTO team = _teamRepository.GetByIdDto(id);
            if (team == null) return NotFound();
            return team;
        }

        [HttpPost]
        public ActionResult<Team> CreateTeam(Team team)
        {
            Team teamToCreate = new Team(team.Naam, team.Toernooi);
            _teamRepository.Add(teamToCreate);
            _teamRepository.SaveChanges();
            return CreatedAtAction(nameof(GetTeam), new { id = teamToCreate.TeamId }, teamToCreate);
        }

        [HttpPut("{id}")]
        public ActionResult<Team> UpdateTeam(int id, TeamDTO team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }
            var tm = _teamRepository.Update(team);
            _teamRepository.SaveChanges();
            return tm;
        }

        [HttpDelete("{id}")]
        public ActionResult<Team> DeleteTeam(int id)
        {
            Team team = _teamRepository.GetById(id);
            if (team == null)
            {
                return NotFound();
            }
            _teamRepository.Delete(team);
            _teamRepository.SaveChanges();
            return team;
        }
    }
}
