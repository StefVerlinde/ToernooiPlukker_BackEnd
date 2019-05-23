using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.DTOs;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Team> _team;

        public TeamRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _team = dbContext.Team_Domain;
        }
        public void Add(Team team)
        {
            _team.Add(team);
        }

        public void Delete(Team team)
        {
            _team.Remove(team);
        }

        public IEnumerable<TeamDTO> GetAll()
        {
            return fromListToDtoList(_team.Include(t => t.Toernooi).ThenInclude(t => t.Creator).ToList());
        }

        public Team GetById(int id)
        {
            return _team.SingleOrDefault(t => t.TeamId == id);
        }

        public TeamDTO GetByIdDto(int id)
        {
            return new TeamDTO(_team.Include(t => t.Toernooi).ThenInclude(t => t.Creator).SingleOrDefault(t => t.TeamId == id));
        }

        public IEnumerable<TeamDTO> GetByToernooiId(int id)
        {
            return fromListToDtoList(_team.Include(t => t.Toernooi).ThenInclude(t => t.Creator).Where(t => id == t.Toernooi.ToernooiId));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Team Update(Team team)
        {
            var t = GetById(team.TeamId);
            team.Naam = team.Naam;
            _context.Update(t);
            _context.SaveChanges();
            return GetById(t.TeamId);
        }

        private ICollection<TeamDTO> fromListToDtoList(IEnumerable<Team> teams)
        {
            ICollection<TeamDTO> teamDTO = new List<TeamDTO>();
            foreach (Team t in teams)
            {
                teamDTO.Add(new TeamDTO(t));
            }
            return teamDTO.ToList();
        }
    }
}
