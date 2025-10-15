using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Dtos.Room;
using HotelReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        bool AddRoom(HotelRoom room);
        List<HotelRoom> GetAllRoom();
        bool IsExistRoom(string roomNumber);   
        bool IsExistRoom(int roomId);

    }
}
