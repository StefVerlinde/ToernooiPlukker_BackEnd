using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI.DTOs
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string Naam { get; set; }
        public ToernooiDTO Toernooi { get; set; }

        public TeamDTO(Team team)
        {
            if (team != null)
            {
                TeamId = team.TeamId;
                Naam = team.Naam;
                Toernooi = new ToernooiDTO(team.Toernooi);

            }
        }
    }
}
