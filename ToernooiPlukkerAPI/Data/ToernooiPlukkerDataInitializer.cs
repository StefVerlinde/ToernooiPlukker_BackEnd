using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data
{
    public class ToernooiPlukkerDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public ToernooiPlukkerDataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                IEnumerable<User> users = new List<User>
                {
                    new User("Stef", "Verlinde", "stefverlinde@hotmail.com", "test123"),
                    new User("Bernard", "Deploige", "bernarddeploige@hotmail.com", "test123"),
                    new User("Tijs", "Martens", "tijsmartens@hotmail.com", "test123"),
                    new User("Uche", "Osajie", "ucheosajie@hotmail.com", "test123")
                };


                foreach (User u in users)
                {
                    _dbContext.Users.Add(u);
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
