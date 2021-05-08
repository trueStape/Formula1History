using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class RaceWeekendModel
    {
        public Guid Id { get; set; }
        public Guid RaceYearEntityId { get; set; }
        public string RaceName { get; set; }
        public string Country { get; set; }
        public string Descriptions { get; set; }
        public DateTime StartWeekend { get; set; }
        public DateTime FinishWeekend { get; set; }
        public DriverModel FastLap { get; set; }
        public List<TeamModel> Teams { get; set; }

        public List<RacePlaceModel> Results { get; set; }
    }
}