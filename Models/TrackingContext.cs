using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace RealTimeUber.Models
{
    public class TrackingContext : IdentityDbContext
    {
        public TrackingContext(DbContextOptions<TrackingContext> options):base(options) 
        { }
        


        public DbSet<Location> Locations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Request> Requests { get; set; }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<Trip>()
            //.HasOne(t => t.Vehicle)
            //.WithMany()
            //.HasForeignKey(t => t.VehicleId);

            //    modelBuilder.Entity<Rating>()
            //        .HasOne(r => r.Driver)
            //        .WithMany(d => d.Ratings)
            //        .HasForeignKey(r => r.DriverId);

            //    modelBuilder.Entity<Request>()
            //        .HasOne(r => r.Driver)
            //        .WithMany();

            //    modelBuilder.Entity<Payment>()
            //        .HasOne(p => p.Trip)
            //        .WithMany();

            //    modelBuilder.Entity<Notification>()
            //        .HasOne(n => n.IdentityUser)
            //        .WithMany(u => u.Notifications);




            //    modelBuilder.Entity<Driver>()
            //        .HasMany(d => d.Trips)
            //        .WithOne(t => t.Driver)
            //        .HasForeignKey(t => t.DriverId);

      

            base.OnModelCreating(modelBuilder);
        }
    }

}
