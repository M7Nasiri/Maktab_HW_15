using HotelReservation.Domain.Entities;
using HotelReservation.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Persistence
{
    public class AppDbContext :DbContext
    {
        public AppDbContext()
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<HotelRoom> Rooms { get; set; }
        public DbSet<RoomDetail> RoomDetails { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-6U51JF85\SQL2022;Database=Maktab135_HW_15;Trusted_Connection=True;TrustServerCertificate=True;");

            //optionsBuilder.UseSqlServer(@"Server=LAPTOP-6U51JF85\SQL2022;Database=Maktab135_HW_15;Trusted_Connection=True;TrustServerCertificate=True;")
            //  .EnableRetryOnFailure();
            //optionsBuilder.UseSqlServer(@"Server=LAPTOP-6U51JF85\SQL2022;Database=Maktab135_HW_15;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new HotelRoomConfiguration());
        }
    }
}
