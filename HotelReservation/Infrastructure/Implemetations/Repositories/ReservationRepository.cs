using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Dtos.Reservation;
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
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;
        public ReservationRepository()
        {
            _context = new AppDbContext();
        }
        public int CreateReservation(CreateReservationDto createReservationDto)
        {
            var reservation = new Reservation
            {
                CheckOutDate = createReservationDto.CheckOutDate,
                CheckInDate = createReservationDto.CheckInDate,
                RoomId = createReservationDto.RoomId,
                Status = createReservationDto.Status,
                UserId = createReservationDto.UserId,
            };
            _context.Add(reservation);
            _context.SaveChanges();
            int resId = reservation.Id;
            return resId;
        }
        public List<GetReservationDto> GetAllReservationByUser(int userId)
        {
            return _context.Reservations.Include(c=>c.User).Include(c=>c.Room).Where(c => c.UserId == userId).Select(c => new GetReservationDto
            {
                Id = c.Id,
                CheckInDate = c.CheckInDate,
                CheckOutDate = c.CheckOutDate,
                CreatedAt = c.CreatedAt,
                RoomId = c.RoomId,
                Status = c.Status,
                UserId = c.UserId
            }).ToList();
        }

        public GetReservationDto GetReservationByReserveId(int reserveId)
        {
            return _context.Reservations.Include(c => c.User).Include(c => c.Room).Where(c => c.Id == reserveId).Select(c => new GetReservationDto
            {
                Id = c.Id,
                CheckInDate = c.CheckInDate,
               CheckOutDate = c.CheckOutDate,
               CreatedAt = c.CreatedAt,
               RoomId = c.RoomId,
               Status = c.Status,
               UserId = c.UserId
            }).FirstOrDefault();
        }

        public RoomAvailableResult IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut.Date < checkIn.Date)
                return RoomAvailableResult.FailureResult("CheckOut Date must after CheckIn Date!");
            if (!_context.Reservations
                .Any(r => r.RoomId == roomId &&
                               r.Status != Status.Cancelled &&
                               (
                                   (checkIn >= r.CheckInDate && checkIn < r.CheckOutDate) ||
                                   (checkOut > r.CheckInDate && checkOut <= r.CheckOutDate) ||
                                   (checkIn <= r.CheckInDate && checkOut >= r.CheckOutDate)
                               )))
            {
                return RoomAvailableResult.SuccessResult($"Room {roomId} available for reservation!");
            }
            else
            {
                return RoomAvailableResult.FailureResult($"Room {roomId} has been reserved before!");
            }
        }

        public bool UpdateStatus(int reserveId, Status status)
        {
            var res = _context.Reservations.Where(r=>r.Id == reserveId)
                .ExecuteUpdate(setters=>setters.SetProperty(r=>r.Status, status));
            return res != 0;
        }
    }
}
