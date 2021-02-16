using System;

namespace BLL.Models
{
    public class DriverModel : PeopleModel 
    {
        public Guid Id { get; set; }
        public int CarNumber { get; set; }
    }
}