using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace AirlineReservationApp.Models

{
    public class AirlineSys_DbContext : DbContext
    {

        public AirlineSys_DbContext(DbContextOptions<AirlineSys_DbContext> options)
           : base(options)
        {
        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }

        //public DbSet<FligthBooking> FligthBookings { get; set; }
        //public DbSet<TicketReservation> TicketReservations { get; set; } = default!;

        public DbSet<Aeroplane> Aeroplanes { get; set; }
        public DbSet<AeroplaneImage> AeroplaneImages { get; set; }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<AirlineCompany> AirlineCompanies { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            
            
            modelBuilder.Entity<Aeroplane>()
                .HasMany(a => a.Flights)
                .WithOne(f => f.Aeroplane)
                .HasForeignKey(f => f.PlaneID);




            modelBuilder.Entity<Aeroplane>()
            .HasOne(e => e.AirlineCompanyNavigationKey)//ForeignKey
            .WithMany(s => s.Aeroplanes)
            .HasForeignKey(e => e.AirlineCompanyId)
            .HasConstraintName("FK_Aeroplanes_ACompanies");//ForeignKey Constrant

            



            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Bookings)
                .WithOne(b => b.Flight)
                .HasForeignKey(b => b.FligthId);

           
            
            
            modelBuilder.Entity<AeroplaneImage>()
         .HasOne(ai => ai.Aeroplane) 
         .WithMany(a => a.AeroplaneImages) 
         .HasForeignKey(ai => ai.AeroplaneId); 
        }


    }

}
