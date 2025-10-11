using HotelReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Session
{
    public class SessionContext
    {
        public static User CurrentUser { get; set; }
    }
}
