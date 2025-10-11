using HotelReservation.Application.Interfaces.Services;
using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Entities;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService()
        {
            _userRepo = new UserRepository();
        }

        public List<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public bool IsExistUser(int userId)
        {
            return _userRepo.IsExistUser(userId);
        }

        public bool IsNormalUser(int userId)
        {
            return _userRepo.IsNormalUser(userId);
        }

        public LoginResult<User> Login(string userName, string password)
        {
            return _userRepo.Login(userName, password);
        }

        public bool register(string userName, string password, Roles role)
        {
            return _userRepo.register(userName, password,role);
        }
    }
}
