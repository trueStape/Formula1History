using DAL.Entities.Race;

namespace DAL.Entities.Team
{
    public class TimeInTeam
    {
        public TeamEntity Team { get; set; }
        public RaceYearEntity RaceYear { get; set; }
    }
}