using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToernooiPlukkerAPI.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        public String Naam { get; set; }

        [Required]
        public String Achternaam { get; set; }

        [Required]
        [Compare("Wachtwoord")]
        public String WachtwoordConfirm { get; set; }
    }
}
