using DAL.Entities.Peoples;
using DAL.Entities.Race;
using DAL.Entities.Team;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {

        }

        //TODO 1 [Done] Add Entity relationship
        public DbSet<DriverEntity> Driver { get; set; }
        public DbSet<ManagerEntity> Manager { get; set; }
        public DbSet<RaceWeekendEntity> RaceWeekend { get; set; }
        public DbSet<RaceYearEntity> RaceYear { get; set; }
        public DbSet<TeamEntity> Team { get; set; }
        public DbSet<ConnectionTeamAndRaceWeekend> ConnectionTeamAndRaceWeekend { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO 2 Add Entity relationship
            //modelBuilder.Entity<UserInformationEntity>()
            //    .HasOne(x => x.Department)
            //    .WithMany(x => x.Users)
            //    .HasForeignKey(x => x.DepartmentId);


            //modelBuilder.Entity<UserEntity>()
            //    .HasOne(x => x.UserInformation)
            //    .WithOne(x => x.User)
            //    .HasForeignKey<UserInformationEntity>(x => x.UserId);
        }
    }
}