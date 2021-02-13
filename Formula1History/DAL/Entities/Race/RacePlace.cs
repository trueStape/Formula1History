using System;
using System.ComponentModel.DataAnnotations;
using DAL.Entities.Peoples;

namespace DAL.Entities.Race
{
    public class RacePlace
    {
        [Key]
        public Guid Id { get; set; }
        public int Place { get; set; }
        public int Pts { get; set; }
        public DriverEntity Driver { get; set; }
    }
}