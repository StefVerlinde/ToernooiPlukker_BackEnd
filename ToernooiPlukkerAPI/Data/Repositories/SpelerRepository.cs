using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Speler> GetAll()
        {
            return _speler.ToList();
        }

        public Speler GetById(int id)
        {
            return _speler.SingleOrDefault(s => s.SpelerId == id);
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
    }
}
