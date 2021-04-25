using System;
using System.ComponentModel.DataAnnotations;
using DAL.Entities.Peoples;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities.Race
{
    public class RacePlace
    {
        [Key]
        public Guid RaceWeekendId { get; set; }
        public int Place { get; set; }
        public int Pts { get; set; }
        public Guid DriverId { get; set; }
        public DriverEntity Driver { get; set; }
    }
}