using System.Collections.Generic;
using ToernooiPlukkerAPI.DTOs;

namespace ToernooiPlukkerAPI.Models
{
    public interface ITeamRepository
    {
        IEnumerable<TeamDTO> GetAll();
        Team GetById(int id);
        TeamDTO GetByIdDto(int id);
        IEnumerable<TeamDTO> GetByToernooiId(int id);
        void Add(Team team);
        void Delete(Team team);
        Team Update(Team team);
        void SaveChanges();
    }
}
