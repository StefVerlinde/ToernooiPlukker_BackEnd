using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.DTOs;

namespace ToernooiPlukkerAPI.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        UserDTO GetByEmail(string email);
        void Add(User user);
        void Delete(User user);
        UserDTO Update(UserDTO user);
        void SaveChanges();
    }
}
