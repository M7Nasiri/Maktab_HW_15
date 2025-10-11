namespace HotelReservation.Application.ResultPattern
{
    public class LoginResult<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public static LoginResult<T> SuccessResult(T data) => new LoginResult<T> { Success = true, Data = data };
        public static LoginResult<T> FailureResult(string errorMessage) => new LoginResult<T> { Success = false, ErrorMessage = errorMessage };
    }
}
