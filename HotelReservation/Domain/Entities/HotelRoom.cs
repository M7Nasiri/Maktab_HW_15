using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entities
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int PricePerNight { get; set; }
        public DateTime CreatedAt { get; set; }
        public RoomDetail? RoomDetails { get; set; }
        public List<Reservation> Reservations { get; set; }
        public HotelRoom()
        {
            Reservations = [];
        }
    }
}
