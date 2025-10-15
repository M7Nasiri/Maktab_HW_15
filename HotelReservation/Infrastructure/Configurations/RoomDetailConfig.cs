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
    public class RoomDetailConfig : IEntityTypeConfiguration<RoomDetail>
    {
        public void Configure(EntityTypeBuilder<RoomDetail> builder)
        {
            builder.HasData(
            new RoomDetail
            {
                Id = 1,
                Description = "Bad",
                HasAirConditioner = false,
                HasWifi = false,
                RoomId = 1
            },
            new RoomDetail
            {
                Id = 2,
                Description = "Good",
                HasAirConditioner = false,
                HasWifi = true,
                RoomId = 2
            },
            new RoomDetail
            {
                Id = 3,
                Description = "Good",
                HasAirConditioner = true,
                HasWifi = false,
                RoomId = 3
            }
    );
        }
    }
}
