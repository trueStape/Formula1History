using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class RaceYearModel
    {
        public Guid Id { get; set; }
        public string Year { get; set; }
        public List<RaceWeekendModel> RacesWeekends { get; set; }
    }
}