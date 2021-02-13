using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Race
{
    public class RaceYearEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Year { get; set; }
        public List<RaceWeekendEntity> RacesWeekends { get; set; }
    }
}