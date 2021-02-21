using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class TeamModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime YearFoundation { get; set; }
        public DateTime YearClose { get; set; }
        public string Description { get; set; }
        public TeamModel NextTeam { get; set; }
        public List<DriverModel> Drivers { get; set; }
        public List<ManagerModel> Managers { get; set; }
    }
}