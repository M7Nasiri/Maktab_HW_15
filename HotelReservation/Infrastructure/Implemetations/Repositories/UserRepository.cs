using HotelReservation.Application.ResultPattern;
using HotelReservation.Application.Session;
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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository()
        {
            _context = new AppDbContext();
        }

        public List<User> GetAll()
        {
            return _context.Users.Where(u=>u.Role == Roles.NormalUser).ToList();
        }

        public bool IsExistUser(int userId)
        {
            return _context.Users.Any(u=>u.Id == userId);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u=>u.UserName == userName);
        }

        public bool IsNormalUser(int userId)
        {
            if (_context.Users.Any(u => u.Id == userId && u.Role == Roles.NormalUser))
                return true;
            return false;
        }

        public LoginResult<User> Login(string userName, string password)
        {
            var user = _context.Users.FirstOrDefault(c => c.UserName == userName && c.Password == password);
            if (user == null || user.Password != password)
            {
                //SessionContext.CurrentUser = user;
                return LoginResult<User>.FailureResult("Invalid username or password.");
            }
            return LoginResult<User>.SuccessResult(user);
        }

        public bool register(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }

       
    }
}
