using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace RealTimeUber.Models
{
    public class TrackingContext : IdentityDbContext<ApplicationUser>
    {

        public TrackingContext(DbContextOptions<TrackingContext> options) : base(options)
        { }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Passenger> Passenger { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Request> Requests { get; set; }

        public DbSet<Payment> Payments { get; set; }

        // Location DbSet
        //public DbSet<Location> Locations { get; set; }

        public DbSet<StartLocation> StartLocations { get; set; }
        public DbSet<EndLocation> EndLocations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {







            modelBuilder.Entity<ApplicationUser>()
           .HasKey(u => u.Id);



            modelBuilder.Entity<IdentityUserLogin<string>>()
    .HasKey(l => new { l.UserId, l.LoginProvider });


            modelBuilder.Entity<IdentityUserRole<string>>()
    .HasKey(r => new { r.RoleId, r.UserId });


            modelBuilder.Entity<IdentityUserToken<string>>()
    .HasKey(t => new { t.UserId, t.LoginProvider });



            modelBuilder.Entity<Request>()
       .HasOne(r => r.Passenger)
       .WithMany()
       .HasForeignKey(r => r.PassengerId)
       .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Request>()
       .HasOne(r => r.StartLocation)
       .WithMany()
       .HasForeignKey(r => r.StartLocationId)
       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Request>()
       .HasOne(r => r.EndLocation)
       .WithMany()
       .HasForeignKey(r => r.EndLocationId)
       .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Trip>()
   .HasOne(t => t.Driver)
   .WithMany()
   .HasForeignKey(t => t.DriverId)
   .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Trip>()
.HasOne(t => t.Vehicle)
.WithMany()
.HasForeignKey(t => t.VehicleId)
.OnDelete(DeleteBehavior.NoAction);

            //          modelBuilder.Entity<Vehicle>()
            // .HasOne(t => t.Driver)
            // .WithMany()
            // .HasForeignKey(t => t.DriverId)
            // .OnDelete(DeleteBehavior.NoAction);



            //          modelBuilder.Entity<Vehicle>()
            //.HasMany(v => v.Trips)
            //.WithOne(t => t.Vehicle);


        }
    }

}
