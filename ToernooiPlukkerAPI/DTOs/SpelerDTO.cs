using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.DTOs
{
    public class SpelerDTO
    {
        public int SpelerId { get; set; }
        public string Naam { get; set; }
        public string Achternaam { get; set; }
        public int Sterkte { get; set; }
        public string Geslacht { get; set; }
        public string Functie { get; set; }
        public TeamDTO Team { get; set; }

        public SpelerDTO(Speler speler)
        {
            if (speler != null)
            {
                SpelerId = speler.SpelerId;
                Naam = speler.Naam;
                Achternaam = speler.Achternaam;
                Sterkte = speler.Sterkte;
                Geslacht =speler.Geslacht;
                Functie = speler.Functie;
                Team = new TeamDTO(speler.Team);
            }
        }
    }
}
