using HotelReservation.Domain.Dtos;
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
        ResultDto AddRoom(CreateRoomDto createRoomDto);
        List<GetRoomDto> GetAllRoom();
        bool IsExistRoom(string roomNumber);
        bool IsExistRoom(int roomId);
    }
}
