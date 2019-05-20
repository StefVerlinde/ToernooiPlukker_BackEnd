using System.Collections.Generic;

namespace ToernooiPlukkerAPI.Models
{
    public interface IToernooiRepository
    {
        IEnumerable<Toernooi> GetAll();
        Toernooi GetById(int id);
        IEnumerable<Toernooi> GetByUserId(int id);
        void Add(Toernooi toernooi);
        void Delete(Toernooi toernooi);
        Toernooi Update(Toernooi toernooi);
        void SaveChanges();
    }
}
