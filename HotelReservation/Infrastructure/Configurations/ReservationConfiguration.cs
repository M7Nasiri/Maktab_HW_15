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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.Status).HasConversion<string>();

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GetDate()");

            builder.Property(r => r.CheckInDate)
              .IsRequired();

            builder.Property(r => r.CheckOutDate)
                   .IsRequired();

           

        }
    }
}
