using HotelReservation.Application.Interfaces.Services;
using HotelReservation.Domain.Dtos;
using HotelReservation.Domain.Dtos.Room;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Interfaces.Repositories;
using HotelReservation.Infrastructure.Implemetations.Repositories;
using Microsoft.EntityFrameworkCore;
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
        public ResultDto AddRoom(CreateRoomDto createRoomDto)
        {
            if(_roomRepo.IsExistRoom(createRoomDto.RoomNumber))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Duplicate room number"
                };
            }
            var room = new HotelRoom
            {
                Capacity = createRoomDto.Capacity,
                CreatedAt = DateTime.Now,
                PricePerNight = createRoomDto.PricePerNight,
                RoomNumber = createRoomDto.RoomNumber,
                RoomDetails = new RoomDetail
                {
                    Description = createRoomDto.Description,
                    HasAirConditioner = createRoomDto.HasAirConditioner,
                    HasWifi = createRoomDto.HasWifi,
                    
                }
            };
            try
            {
                _roomRepo.AddRoom(room);
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "Room Added successfully!"
                };
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Error on Add room!"
                };
            }
        }

        public List<GetRoomDto> GetAllRoom()
        {
            var rooms = _roomRepo.GetAllRoom();
            return rooms.Select(r => new GetRoomDto
            {
                RoomNumber = r.RoomNumber,
                Capacity = r.Capacity,
                Description = r.RoomDetails?.Description ?? "—",
                HasAirConditioner = r.RoomDetails?.HasAirConditioner ?? false,
                HasWifi = r.RoomDetails?.HasWifi ?? false,
                PricePerNight = r.PricePerNight,
                Id = r.Id
            }).ToList();
        }

        public bool IsExistRoom(string roomNumber)
        {
            return _roomRepo.IsExistRoom(roomNumber);
        }
        bool IsExistRoom(int roomId)
        {
            return _roomRepo.IsExistRoom(roomId);
        }

        bool IRoomService.IsExistRoom(int roomId)
        {
            return _roomRepo.IsExistRoom(roomId);
        }
    }
}
