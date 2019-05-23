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
        private int _aantalSpelers;

        public int TeamId { get; set; }
        public string Naam {
            get => _naam;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naam mag niet leeg zijn");
                _naam = value;
            }
        }
        public int AantalSpelers {
            get => _aantalSpelers;
            set {
                if (value <= 0)
                    throw new ArgumentException("Aantal spelers moet hoger dan 0 zijn");
                _aantalSpelers = value;
            }
        }

        public Collection<Speler> Spelers { get; set; }

        public Toernooi Toernooi { get; set; }

        public Team() { }

        public Team(string naam, int aantalSpelers,Toernooi toernooi)
        {
            Naam = naam;
            AantalSpelers = aantalSpelers;
            Spelers = new Collection<Speler>();
            Toernooi = toernooi;
        }

        public void addSpeler(Speler speler)
        {
            if (speler == null)
                throw new ArgumentException("Speler mag niet leeg zijn");
            Spelers.Add(speler);
        }
    }
}
