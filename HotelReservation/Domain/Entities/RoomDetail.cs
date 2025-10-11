using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entities
{
    public class RoomDetail
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool HasWifi { get; set; }
        public bool HasAirConditioner { get; set; }
        public int RoomId { get; set; }
        public HotelRoom? Room { get; set; }
    }
}
