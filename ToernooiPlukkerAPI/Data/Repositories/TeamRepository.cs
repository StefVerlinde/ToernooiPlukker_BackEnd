using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Team> GetAll()
        {
            return _team.ToList();
        }

        public Team GetById(int id)
        {
            return _team.SingleOrDefault(t => t.TeamId == id);
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
    }
}
