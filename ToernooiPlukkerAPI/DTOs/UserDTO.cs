using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToernooiPlukkerAPI.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Wachtwoord { get; set; }
    }
}
