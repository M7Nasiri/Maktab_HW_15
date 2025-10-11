using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Dtos.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        bool AddRoom(CreateRoomDto createRoomDto);
        List<GetRoomDto> GetAllRoom();
        bool IsExistRoom(int roomId);   
       
    }
}
