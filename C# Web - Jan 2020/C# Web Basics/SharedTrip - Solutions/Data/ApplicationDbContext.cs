namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;
    using System.Linq;

    public class ApplicationDbContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserTrip> UserTrip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<UserTrip>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.TripId});
            });

            builder.Entity<UserTrip>()
                .HasOne(ut=>ut.User)
                .WithMany(u=>u.UserTrips);

            builder.Entity<UserTrip>()
                .HasOne(ut => ut.Trip)
                .WithMany(t => t.UserTrips);
        }
    }
}
