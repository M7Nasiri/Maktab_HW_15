using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Dtos.Reservation;
using HotelReservation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        //List<GetReservationDto> GetAllReservationByUser(string userName);
        List<GetReservationDto> GetAllReservationByUser(int userId);
        GetReservationDto GetReservationByReserveId(int  reserveId);
        int CreateReservation(CreateReservationDto createReservationDto);
        RoomAvailableResult IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut);
        bool UpdateStatus(int reserveId, Status status);

    }
}
