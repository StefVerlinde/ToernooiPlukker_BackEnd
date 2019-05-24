using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ToernooiPlukkerAPI.Models
{
    public class Team
    {
        private string _naam;

        public int TeamId { get; set; }
        public string Naam {
            get => _naam;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naam mag niet leeg zijn");
                _naam = value;
            }
        }

        public Collection<Speler> Spelers { get; set; }

        public Toernooi Toernooi { get; set; }

        public Team() { }

        public Team(string naam, Toernooi toernooi)
        {
            Naam = naam;
            Toernooi = toernooi;
        }
    }
}
