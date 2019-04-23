using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.Data
{
    public class ToernooiPlukkerDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public ToernooiPlukkerDataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                IEnumerable<User> users = new List<User>
                {
                    new User("Stef", "Verlinde", "stefverlinde@hotmail.com"),
                    new User("Bernard", "Deploige", "bernarddeploige@hotmail.com"),
                    new User("Tijs", "Martens", "tijsmartens@hotmail.com"),
                    new User("Uche", "Osajie", "ucheosajie@hotmail.com")
                };


                foreach (User u in users)
                {
                    _dbContext.Users_Domain.Add(u);
                    var email = u.Email;
                    var wachtwoord = "P@ssword1";
                    var role = "User";
                    await CreateUser(email, wachtwoord, role);
                }

                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string wachtwoord, string role)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, wachtwoord);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }
    }
}
