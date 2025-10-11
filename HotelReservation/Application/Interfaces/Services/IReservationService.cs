using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Dtos.Reservation;
using HotelReservation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Interfaces.Services
{
    public interface IReservationService
    {
        List<GetReservationDto> GetAllReservationByUser(int userId);
        GetReservationDto GetReservationByReserveId(int reserveId);
        RoomAvailableResult CreateReservation(CreateReservationDto createReservationDto);
        bool UpdateStatus(int reserveId, Status status);
       // RoomAvailableResult IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut);
    }
}
