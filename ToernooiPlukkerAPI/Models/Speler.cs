using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToernooiPlukkerAPI.Models
{
    public class Speler
    {
        private string _naam;
        private string _achterNaam;
        private int _sterkte;

        public int SpelerId { get; set; }

        public string Naam {
            get => _naam;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naam mag niet leeg zijn");
                _naam = value;
            }
        }

        public string Achternaam {
            get => _achterNaam;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Achternaams mag niet leeg zijn");
                _achterNaam = value;
            }
        }

        public int Sterkte {
            get => _sterkte;
            set {
                if (value < 1 || value > 10)
                    throw new ArgumentException("Sterkte moet tussen 1 en 10 liggen");
                _sterkte = value;
            }
        }

        public string Geslacht { get; set; }

        public string Functie { get; set; }

        public Team Team { get; set; }

        public Speler() { }

        public Speler(string naam, string achternaam, int sterkte, string geslacht, string functie, Team team)
        {
            Naam = naam;
            Achternaam = achternaam;
            Sterkte = sterkte;
            Geslacht = geslacht;
            Functie = functie;
            Team = team;
        }
    }
}
