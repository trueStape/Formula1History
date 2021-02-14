using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities.Peoples;
using DAL.Entities.Team;

namespace DAL.Entities.Race
{
    public class RaceWeekendEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string RaceName { get; set; }
        public string Country { get; set; }
        public string Descriptions { get; set; }
        public DateTime StartWeekend { get; set; }
        public DateTime FinishWeekend { get; set; }
        public DriverEntity FastLap { get; set; }
        public List<TeamEntity> Teams { get; set; }

        public List<RacePlace> Results { get; set; }
        //TODO 4 Add details for laps 
    }
}