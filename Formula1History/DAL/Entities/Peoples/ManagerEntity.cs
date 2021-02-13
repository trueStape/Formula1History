using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities.Team;

namespace DAL.Entities.Peoples
{
    public class ManagerEntity : People
    {
        [Key]
        public Guid Id { get; set; }
        public List<TeamEntity> Teams { get; set; }
        public TimeInTeam TimeInTeam { get; set; }

    }
}