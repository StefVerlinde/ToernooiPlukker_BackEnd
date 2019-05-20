using System.Collections.Generic;

namespace ToernooiPlukkerAPI.Models
{
    public interface ISpelerRepository
    {
        IEnumerable<Speler> GetAll();
        Speler GetById(int id);
        void Add(Speler speler);
        void Delete(Speler speler);
        Speler Update(Speler speler);
        void SaveChanges();
    }
}
