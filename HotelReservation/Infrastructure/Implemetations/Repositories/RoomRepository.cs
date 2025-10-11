using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Dtos.Room;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;
using HotelReservation.Domain.Interfaces.Repositories;
using HotelReservation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Implemetations.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;
        public RoomRepository()
        {
            _context = new AppDbContext();
        }
        public bool AddRoom(CreateRoomDto createRoomDto)
        {
            bool exists = _context.Rooms
        .Any(r => r.RoomNumber == createRoomDto.RoomNumber);
            if (exists)
            {
                return false;
            }
            var room = new HotelRoom
            {
                RoomNumber = createRoomDto.RoomNumber,
                Capacity = createRoomDto.Capacity,
                PricePerNight = createRoomDto.PricePerNight,
                CreatedAt = DateTime.Now,
                RoomDetails = new RoomDetail
                {
                    Description = createRoomDto.Description,
                    HasAirConditioner = createRoomDto.HasAirConditioner,
                    HasWifi = createRoomDto.HasWifi,
                }
            };
            _context.Add(room);
            return _context.SaveChanges() > 0;
        }

        public List<GetRoomDto> GetAllRoom()
        {
            return _context.Rooms.Include(r => r.RoomDetails).Select(r => new GetRoomDto
            {
                RoomNumber = r.RoomNumber,
                Capacity = r.Capacity,
                Description = r.RoomDetails.Description != null ? r.RoomDetails.Description : "—",
                HasAirConditioner = r.RoomDetails != null && r.RoomDetails.HasAirConditioner,
                HasWifi = r.RoomDetails != null && r.RoomDetails.HasWifi,
                PricePerNight = r.PricePerNight,
                Id = r.Id
            }).ToList();
        }

        public bool IsExistRoom(int roomId)
        {
           return _context.Rooms.Any(r=>r.Id == roomId);
        }
    }
}
