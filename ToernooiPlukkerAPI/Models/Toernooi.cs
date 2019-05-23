using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ToernooiPlukkerAPI.Models
{
    public class Toernooi
    {
        private string _naam;
        private DateTime _datum;
        private int _aantalSpelers;
        private int _aantalTeams;

        public int ToernooiId { get; set; }
        public string Naam {
            get => _naam;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naam mag niet leeg zijn");
                _naam = value;
            }
        }
        public DateTime Datum {
            get => _datum;
            set {
                if(value == null /*|| value.Date < DateTime.Now*/)
                    throw new ArgumentException("Datum mag niet leeg zijn");
                _datum = value;
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

        public int AantalTeams {
            get => _aantalTeams;
            set {
                if (value <= 0)
                    throw new ArgumentException("Aantal teams moet hoger dan 0 zijn");
                _aantalTeams = value;
            }
        }

        public User Creator { get; set; }

        public Collection<Team> Teams { get; set; }

        public Toernooi(string naam, DateTime datum, int aantalSpelers, int aantalTeams, User creator)
        {
            Naam = naam;
            Datum = datum;
            AantalSpelers = aantalSpelers;
            Creator = creator;
            AantalTeams = aantalTeams;
            Teams = new Collection<Team>();
        }

        public Toernooi() { }

        public void addTeam(Team team)
        {
            if (team == null)
                throw new ArgumentException("Team mag niet null zijn");
           Teams.Add(team);
        }
    }
}
