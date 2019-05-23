using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.DTOs;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data.Repositories
{
    public class ToernooiRepository : IToernooiRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Toernooi> _toernooi;

        public ToernooiRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _toernooi = dbContext.Toernooi_Domain;
        }
        public void Add(Toernooi toernooi)
        {
            _toernooi.Add(toernooi);
        }

        public void Delete(Toernooi toernooi)
        {
            _toernooi.Remove(toernooi);
        }

        public IEnumerable<ToernooiDTO> GetAll()
        {
            return fromListToDtoList( _toernooi.Include(t => t.Creator).ToList());
        }

        public ToernooiDTO GetByIdDto(int id)
        {
            return new ToernooiDTO(_toernooi.Include(t => t.Creator).SingleOrDefault(t => t.ToernooiId == id));
        }

        public Toernooi GetById(int id)
        {
            return _toernooi.SingleOrDefault(t => t.ToernooiId == id);
        }

        public IEnumerable<ToernooiDTO> GetByUserId(int id)
        {
            return fromListToDtoList(_toernooi.Include(t => t.Creator).Where(t => id == t.Creator.UserId));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Toernooi Update(Toernooi toernooi)
        {
            var toer = GetById(toernooi.ToernooiId);
            toer.Naam = toernooi.Naam;
            toer.Datum = toernooi.Datum;
            _context.Update(toer);
            _context.SaveChanges();
            return GetById(toer.ToernooiId);
        }

        private ICollection<ToernooiDTO> fromListToDtoList(IEnumerable<Toernooi> toernooi)
        {
            ICollection<ToernooiDTO> toernooienDTO = new List<ToernooiDTO>();
            foreach (Toernooi t in toernooi)
            {
                toernooienDTO.Add(new ToernooiDTO(t));
            }
            return toernooienDTO.ToList();
        }
    }
}
