using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.DTOs;

namespace ToernooiPlukkerAPI.Models
{
    public class Toernooi
    {
        private string _naam;
        private DateTime _datum;

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

        public User Creator { get; set; }

        public Collection<Team> Teams { get; set; }

        public Toernooi(string naam, DateTime datum, User creator)
        {
            Naam = naam;
            Datum = datum;
            Creator = creator;
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
