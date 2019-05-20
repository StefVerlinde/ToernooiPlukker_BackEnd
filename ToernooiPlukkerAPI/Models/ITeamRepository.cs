using System.Collections.Generic;

namespace ToernooiPlukkerAPI.Models
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        Team GetById(int id);
        void Add(Team team);
        void Delete(Team team);
        Team Update(Team team);
        void SaveChanges();
    }
}
