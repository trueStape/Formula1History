using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities.Team;

namespace DAL.Entities.Peoples
{
    public class ManagerEntity
    {
        [Key]
        public Guid Id { get; set; }
        public List<TeamEntity> Teams { get; set; }
        //TODO 6 Add relationship between RaceYear and Team
        //public TimeInTeam TimeInTeam { get; set; }
    }
}