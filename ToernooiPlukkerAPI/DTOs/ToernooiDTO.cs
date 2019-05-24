using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.DTOs
{
    public class ToernooiDTO
    {
        public int ToernooiId { get; set; }
        public string Naam { get; set; }
        public DateTime Datum { get; set; }
        public UserDTO Creator { get; set; }

        public ToernooiDTO(Toernooi toernooi)
        {
            if(toernooi != null)
            {
                ToernooiId = toernooi.ToernooiId;
                Naam = toernooi.Naam;
                Datum = toernooi.Datum;
                Creator = new UserDTO(toernooi.Creator);
            }
        }
    }
}
