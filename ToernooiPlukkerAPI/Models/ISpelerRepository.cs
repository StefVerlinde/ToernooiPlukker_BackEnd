using System.Collections.Generic;
using ToernooiPlukkerAPI.DTOs;

namespace ToernooiPlukkerAPI.Models
{
    public interface ISpelerRepository
    {
        IEnumerable<SpelerDTO> GetAll();
        Speler GetById(int id);
        SpelerDTO GetByIdDto(int id);
        IEnumerable<SpelerDTO> GetByTeamId(int id);
        void Add(Speler speler);
        void Delete(Speler speler);
        Speler Update(Speler speler);
        void SaveChanges();
    }
}
