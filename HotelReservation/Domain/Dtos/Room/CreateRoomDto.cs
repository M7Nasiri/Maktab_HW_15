using HotelReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Dtos.Room
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int PricePerNight { get; set; }

        //Room Details
        public string Description { get; set; }
        public bool HasWifi { get; set; }
        public bool HasAirConditioner { get; set; }
    }
}
