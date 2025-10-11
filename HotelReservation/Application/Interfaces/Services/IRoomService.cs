using HotelReservation.Domain.Dtos.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Interfaces.Services
{
    public interface IRoomService
    {
        bool AddRoom(CreateRoomDto createRoomDto);
        List<GetRoomDto> GetAllRoom();
        bool IsExistRoom(int roomId);
    }
}
