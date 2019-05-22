using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Token { get; set; }

        public UserDTO(User user)
        {
            if (user != null)
            {
                Id = user.UserId;
                Naam = user.Naam;
                Achternaam = user.Achternaam;
                Email = user.Email;
                Token = user.Token;
            }
        }
    }
}
