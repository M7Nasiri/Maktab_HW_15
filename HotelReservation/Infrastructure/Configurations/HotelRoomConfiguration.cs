using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Configurations
{
    public class HotelRoomConfiguration : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.Property(r => r.RoomNumber).IsRequired().HasMaxLength(20);

            builder.HasIndex(r => r.RoomNumber).IsUnique(true);

            builder.HasMany(room => room.Reservations)
                .WithOne(r => r.Room)
                .HasForeignKey(r=>r.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.RoomDetails)
                .WithOne(rd => rd.Room)
                .HasForeignKey<RoomDetail>(rd => rd.RoomId)
                .IsRequired(false);

            builder.HasData(
               new HotelRoom
               {
                   Id = 1,
                   RoomNumber = "101",
                   Capacity = 4,
                   PricePerNight = 800000,
                   CreatedAt = DateTime.Now,
               },
               new HotelRoom { Id = 2, RoomNumber = "102", Capacity = 2, PricePerNight = 400000, CreatedAt = DateTime.Now },
               new HotelRoom { Id = 3, RoomNumber = "103", Capacity = 3, PricePerNight = 600000, CreatedAt = DateTime.Now }
           );
        }
    }
}
