using HotelReservation.Application.Interfaces.Services;
using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Dtos.Reservation;
using HotelReservation.Domain.Enums;
using HotelReservation.Domain.Interfaces.Repositories;
using HotelReservation.Infrastructure.Implemetations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Implemetations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepo;
        private readonly IUserService _userService;
        public ReservationService()
        {
            _reservationRepo = new ReservationRepository();
            _userService = new UserService();
        }
        public RoomAvailableResult CreateReservation(CreateReservationDto createReservationDto)
        {
            if (_userService.IsNormalUser(createReservationDto.UserId))
            {
                var res = _reservationRepo.IsRoomAvailable(createReservationDto.RoomId, createReservationDto.CheckInDate, createReservationDto.CheckOutDate);
                if (res.IsSuccess)
                {
                    int resId = _reservationRepo.CreateReservation(createReservationDto);
                    return RoomAvailableResult.SuccessResult(res.Message, resId);
                }
                else
                {
                    return RoomAvailableResult.FailureResult(res.Message);
                }
            }
            return RoomAvailableResult.FailureResult("You are not normal user");
            

        }

        public List<GetReservationDto> GetAllReservationByUser(int userId)
        {
            return _reservationRepo.GetAllReservationByUser(userId);
        }

        public GetReservationDto GetReservationByReserveId(int reserveId)
        {
            return _reservationRepo.GetReservationByReserveId(reserveId);
        }

        public bool UpdateStatus(int reserveId, Status status)
        {
            return _reservationRepo.UpdateStatus(reserveId, status);
        }
    }
}
