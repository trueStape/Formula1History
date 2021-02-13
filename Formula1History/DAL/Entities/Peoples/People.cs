using System;

namespace DAL.Entities.Peoples
{
    public abstract class People
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateDeath { get; set; }
        public string About { get; set; }
    }
}