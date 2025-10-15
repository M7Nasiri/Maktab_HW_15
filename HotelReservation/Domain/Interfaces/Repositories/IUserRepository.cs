using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        LoginResult<User> Login(string userName, string password);
        bool register(User user);
        List<User> GetAll();
        bool IsExistUser(int userId);
        bool IsExistUserName(string userName);
        bool IsNormalUser(int userId);
    }
}
