using HotelReservation.Application.Interfaces.Services;
using HotelReservation.Domain.Dtos.Room;
using HotelReservation.Domain.Interfaces.Repositories;
using HotelReservation.Infrastructure.Implemetations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Implemetations.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;
        public RoomService()
        {
            _roomRepo = new RoomRepository();
        }
        public bool AddRoom(CreateRoomDto createRoomDto)
        {
            return _roomRepo.AddRoom(createRoomDto);
        }

        public List<GetRoomDto> GetAllRoom()
        {
            return _roomRepo.GetAllRoom();
        }

        public bool IsExistRoom(int roomId)
        {
            return _roomRepo.IsExistRoom(roomId);
        }
    }
}
