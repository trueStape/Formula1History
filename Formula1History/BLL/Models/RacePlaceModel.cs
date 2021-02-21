using System;

namespace BLL.Models
{
    public class RacePlaceModel
    {
        public Guid Id { get; set; }
        public int Place { get; set; }
        public int Pts { get; set; }
        public DriverModel Driver { get; set; }
    }
}