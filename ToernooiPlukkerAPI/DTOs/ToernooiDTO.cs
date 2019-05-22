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
        public int AantalSpelers { get; set; }
        public int AantalTeams { get; set; }
        public UserDTO Creator { get; set; }

        public ToernooiDTO(Toernooi toernooi)
        {
            if(toernooi != null)
            {
                ToernooiId = toernooi.ToernooiId;
                Naam = toernooi.Naam;
                Datum = toernooi.Datum;
                AantalSpelers = toernooi.AantalSpelers;
                AantalTeams = toernooi.AantalTeams;
                Creator = new UserDTO(toernooi.Creator);
            }
        }
    }
}
