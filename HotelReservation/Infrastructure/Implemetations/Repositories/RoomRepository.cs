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
        public bool AddRoom(HotelRoom room)
        {
            _context.Add(room);
            return _context.SaveChanges() > 0;
        }

        public List<HotelRoom> GetAllRoom()
        {
           return _context.Rooms.Include(r => r.RoomDetails).ToList();
        }

        public bool IsExistRoom(string roomNumber)
        {
           return _context.Rooms.Any(r=>r.RoomNumber.Equals(roomNumber));
        }
        public bool IsExistRoom(int roomId)
        {
           return _context.Rooms.Any(r=>r.Id ==roomId);
        }


    }
}
