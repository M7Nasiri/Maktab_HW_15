using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u=>u.UserName).IsUnique(true);

            builder.Property(x => x.Role).HasConversion<string>();

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(50);

            builder.HasMany(u=>u.Reservations)
                .WithOne(r=>r.User)
                .HasForeignKey(r=>r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new User { Id = 1, UserName = "admin", Password = "123", Role = Roles.Admin, CreatedAt = DateTime.Now },
                new User { Id = 2, UserName = "reception", Password = "123", Role = Roles.Receptionist, CreatedAt = DateTime.Now },
                new User { Id = 3, UserName = "user1", Password = "123", Role = Roles.NormalUser, CreatedAt = DateTime.Now }
            );

        }
    }
}
