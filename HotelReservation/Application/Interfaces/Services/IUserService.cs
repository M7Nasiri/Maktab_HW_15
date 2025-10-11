using HotelReservation.Application.ResultPattern;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Interfaces.Services
{
    public interface IUserService 
    {
        LoginResult<User> Login(string userName, string password);
        bool register(string userName, string password, Roles role);
        List<User> GetAll();
        bool IsExistUser(int userId);
        bool IsNormalUser(int userId);
    }
}
