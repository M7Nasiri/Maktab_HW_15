using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.ResultPattern
{
    public class RoomAvailableResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int ReserveId { get; set; }

        public static RoomAvailableResult SuccessResult(string message,int resId =0)
        {
            return new RoomAvailableResult { IsSuccess = true, Message = message,ReserveId = resId };
        }

        public static RoomAvailableResult FailureResult(string message)
        {
            return new RoomAvailableResult { IsSuccess = false, Message = message };
        }
    }
}
