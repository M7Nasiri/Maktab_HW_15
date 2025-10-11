using HotelReservation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Reservation> Reservations { get; set; }
        public User()
        {
            Reservations = [];
        }
    }
}
