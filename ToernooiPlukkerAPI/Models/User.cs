using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToernooiPlukkerAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Token { get; set; }

        public User(string naam, string achternaam, string email)
        {
            this.Naam = naam;
            this.Achternaam = achternaam;
            this.Email = email;
        }

        public User()
        {
        }
    }
}
