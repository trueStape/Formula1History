using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {

        }
        //TODO 1 Add Entity relationship
        //public DbSet<UserEntity> User { get; set; }

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