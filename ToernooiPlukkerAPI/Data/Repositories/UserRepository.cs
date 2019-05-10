using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.DTOs;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _users = dbContext.Users_Domain;
        }
        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.ToList();
        }

        public UserDTO GetByEmail(string email)
        {
            User user = _users.SingleOrDefault(u => u.Email.Equals(email));
            return new UserDTO(user);
        }

        public User GetById(int id)
        {
            return _users.SingleOrDefault(u => u.UserId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
