using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                //Aanmaken users
                Collection<User> users = new Collection<User>
                {
                    new User("Test", "Testman", "a@a.com"),
                    new User("Stef", "Verlinde", "stefverlinde@hotmail.com"),
                    new User("Bernard", "Deploige", "bernarddeploige@hotmail.com"),
                    new User("Tijs", "Martens", "tijsmartens@hotmail.com"),
                    new User("Uche", "Osajie", "ucheosajie@hotmail.com")
                };

                //Aanmaken toernooien
                users[0].addToernooi(new Toernooi("Clubtoernooi 2017", new DateTime(2017, 04, 25), 20, 4, users[0]));
                users[0].addToernooi(new Toernooi("Clubtoernooi 2018", new DateTime(2018, 04, 25), 20, 4, users[0]));
                users[1].addToernooi(new Toernooi("Clubtoernooi 2019", new DateTime(2019, 04, 25), 20, 4, users[1]));

                //Aanmaken teams met spelers
                foreach (Toernooi t in users[0].Toernooien)
                {
                    for (int i = 0; i < t.AantalTeams; i++)
                    {
                        Team team = new Team($"team{i+1}", t);
                        Collection<Speler> spelers = new Collection<Speler>
                        {
                            new Speler("Stef","Verlinde",10, Geslacht.Man, Functie.Kapitein, team),
                            new Speler("Bernard","Depoige",8, Geslacht.Man, Functie.Speler, team),
                            new Speler("Tijs","Martens",6, Geslacht.Man, Functie.Speler, team),
                            new Speler("Uche","Oesaji",4, Geslacht.Man, Functie.Speler, team),
                            new Speler("Jordy","Detier",2, Geslacht.Man, Functie.Speler, team)
                        };
                        foreach (Speler s in spelers)
                        {
                            team.addSpeler(s);
                        }
                        t.addTeam(team);
                    }
                }
                foreach (Toernooi t in users[1].Toernooien)
                {
                    for (int i = 0; i < t.AantalTeams; i++)
                    {
                        Team team = new Team($"team{i}", t);
                        Collection<Speler> spelers = new Collection<Speler>
                        {
                            new Speler("Stef","Verlinde",10, Geslacht.Man, Functie.Kapitein, team),
                            new Speler("Bernard","Depoige",8, Geslacht.Man, Functie.Speler, team),
                            new Speler("Tijs","Martens",6, Geslacht.Man, Functie.Speler, team),
                            new Speler("Uche","Oesaji",4, Geslacht.Man, Functie.Speler, team),
                            new Speler("Jordy","Detier",2, Geslacht.Man, Functie.Speler, team)
                        };
                        foreach (Speler s in spelers)
                        {
                            team.addSpeler(s);
                        }
                        t.addTeam(team);
                    }
                }
                foreach (User u in users)
                {
                    _dbContext.Users_Domain.Add(u);
                    var email = u.Email;
                    var wachtwoord = "123456789";
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
