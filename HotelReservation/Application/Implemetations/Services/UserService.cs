using HotelReservation.Application.Interfaces.Services;
using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Dtos;
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

        public ResultDto Register(string userName, string password, Roles role)
        {
            if (_userRepo.IsExistUserName(userName))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "UserName is Exist."
                };
            }

            var user = new User
            {
                UserName = userName,
                Password = password,
                Role = role,
                CreatedAt = DateTime.Now
            };

            try
            {
                _userRepo.register(user);

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = $"User {userName} Regist successfully!"
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = $"Error on Regist user"
                };
            }
        }
    }
}
