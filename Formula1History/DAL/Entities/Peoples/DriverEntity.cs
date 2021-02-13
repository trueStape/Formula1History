﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities.Team;

namespace DAL.Entities.Peoples
{
    public class DriverEntity : People
    {
        [Key]
        public Guid Id { get; set; }
        public int CarNumber { get; set; }
        public List<TimeInTeam> Сareer { get; set; }

    }
}