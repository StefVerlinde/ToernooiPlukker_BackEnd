using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ToernooiPlukkerAPI.Models
{
    public class User
    {
        private string _naam;
        private string _achternaam;
        private string _email;
        public int UserId { get; set; }

        [Required]
        public string Naam {
            get => _naam;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Voornaam mag niet leeg zijn");
                _naam = value;
            }
        }

        [Required]
        public string Achternaam {
            get => _achternaam;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Achternaam mag niet leeg zijn");
                _achternaam = value;
            }
        }

        [Required]
        [EmailAddress]
        public string Email {
            get => _email;
            set {
                Regex emailcheck = new Regex(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}");
                if (value == null || !emailcheck.IsMatch(value))
                    throw new ArgumentException("Geen geldig email adress");
                _email = value;
            }
        }

        public string Token { get; set; }

        public Collection<Toernooi> Toernooien { get; set; }

        public User(string naam, string achternaam, string email)
        {
            Naam = naam;
            Achternaam = achternaam;
            Email = email;
            Toernooien = new Collection<Toernooi>();
        }

        public User()
        {
        }

        public void addToernooi(Toernooi toernooi)
        {
            if (toernooi == null)
                throw new ArgumentException("Toernooi mag niet null zijn");
            Toernooien.Add(toernooi);
        }
    }
}
