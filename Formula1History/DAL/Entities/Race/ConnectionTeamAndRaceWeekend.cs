using System;
using System.ComponentModel.DataAnnotations;
using DAL.Entities.Team;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities.Race
{
    public class ConnectionTeamAndRaceWeekend
    {
        [Key]
        public Guid RaceWeekendId { get; set; }
        public Guid TeamId { get; set; }
        public TeamEntity Team { get; set; }
    }
}