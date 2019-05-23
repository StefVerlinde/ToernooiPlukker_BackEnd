using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.DTOs;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data.Repositories
{
    public class SpelerRepository : ISpelerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Speler> _speler;

        public SpelerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _speler = dbContext.Speler_Domain;
        }
        public void Add(Speler speler)
        {
            _speler.Add(speler);
        }

        public void Delete(Speler speler)
        {
            _speler.Remove(speler);
        }

        public IEnumerable<SpelerDTO> GetAll()
        {
            return fromListToDtoList(_speler.Include(s => s.Team).ToList());
        }

        public Speler GetById(int id)
        {
            return _speler.SingleOrDefault(s => s.SpelerId == id);
        }

        public SpelerDTO GetByIdDto(int id)
        {
            return new SpelerDTO(_speler.Include(s => s.Team).SingleOrDefault(s => s.SpelerId == id));
        }

        public IEnumerable<SpelerDTO> GetByTeamId(int id)
        {
            return fromListToDtoList(_speler.Include(s => s.Team).Where(s => id == s.Team.TeamId));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Speler Update(Speler speler)
        {
            var s = GetById(speler.SpelerId);
            s.Naam = speler.Naam;
            s.Achternaam = speler.Achternaam;
            s.Sterkte = speler.Sterkte;
            s.Geslacht = speler.Geslacht;
            s.Functie = speler.Functie;
            _context.Update(s);
            _context.SaveChanges();
            return GetById(s.SpelerId);
        }

        private ICollection<SpelerDTO> fromListToDtoList(IEnumerable<Speler> spelers)
        {
            ICollection<SpelerDTO> spelerDTO = new List<SpelerDTO>();
            foreach (Speler s in spelers)
            {
                spelerDTO.Add(new SpelerDTO(s));
            }
            return spelerDTO.ToList();
        }
    }
}
