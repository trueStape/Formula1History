using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities.Peoples;

namespace DAL.Entities.Team
{
    public class TeamEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime YearFoundation { get; set; }
        public DateTime YearClose { get; set; }
        public string Description { get; set; }
        public Guid NextTeamId { get; set; }
        public List<DriverEntity> Drivers { get; set; }
        public List<ManagerEntity> Managers { get; set; }
    }
}