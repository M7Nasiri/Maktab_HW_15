using HotelReservation.Application.Implemetations.Services;
using HotelReservation.Application.Interfaces.Services;
using HotelReservation.Application.Utils;
using HotelReservation.Domain.Dtos.Reservation;
using HotelReservation.Domain.Dtos.Room;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;
using System.Threading.Channels;

IUserService _userService = new UserService();
IReservationService _reservationService = new ReservationService();
IRoomService _roomService = new RoomService();
bool outerFlag = true;
User currentUser = null;
do
{
    Console.Clear();
    Console.WriteLine("Enter Command");
    Console.WriteLine("1-Register");
    Console.WriteLine("2-Login");
    Console.WriteLine("0-Exit");
    int choice = int.Parse(Console.ReadLine());
    if(choice == 1 )
    {
        Console.WriteLine("Enter UserName");
        string userName = Console.ReadLine();

        Console.WriteLine("Enter Password");
        string password = Console.ReadLine();

        Console.WriteLine("Enter Role (0)Admin, (1)Receptionist (2)NormalUser");
        int role = int.Parse(Console.ReadLine());
        if (_userService.register(userName, password, (Roles)role))
        {
            Console.WriteLine("Register Successfull!");
        }
        else
        {
            Console.WriteLine("UnSuccessfull Register!");
        }
        Console.ReadKey();
    }else if(choice == 2)
    {
        Console.WriteLine("Enter UserName");
        string userName = Console.ReadLine();

        Console.WriteLine("Enter Password");
        string password = Console.ReadLine();
        var res = _userService.Login(userName, password);
        if (res.Success)
        {
            currentUser = res.Data;
            bool innerFlag = true;
            Console.Clear();
            Console.WriteLine("Enter 0 to Exit Or other to Continue");
            int choice1 = int.Parse(Console.ReadLine());
            do
            {
                if (currentUser.Role == HotelReservation.Domain.Enums.Roles.Admin)
                {
                    var rooms = _roomService.GetAllRoom();
                    if (rooms.Count > 0)
                    {
                        foreach (var r in rooms)
                        {
                            Console.WriteLine($"Id: {r.Id} Room number :{r.RoomNumber} {r.Capacity} {r.PricePerNight}");
                        }
                    }
                    Console.WriteLine("Add new Room");

                    Console.WriteLine("Enter Room number");
                    string roomNumber = Console.ReadLine();

                    Console.WriteLine("Enter price");
                    int price = int.Parse(Console.ReadLine());


                    Console.WriteLine("Enter Description");
                    string description = Console.ReadLine();

                    Console.WriteLine("Enter Capacity");
                    int capacity = int.Parse(Console.ReadLine());

                    Console.WriteLine("Has Air Conditioning?");
                    bool hasAir = Convert.ToBoolean(int.Parse(Console.ReadLine()));

                    Console.WriteLine("Has Wifi?");
                    bool hasWifi = Convert.ToBoolean(int.Parse(Console.ReadLine()));

                    CreateRoomDto createRoomDto = new CreateRoomDto
                    {
                        Capacity = capacity,
                        Description = description,
                        HasAirConditioner = hasAir,
                        HasWifi = hasWifi,
                        PricePerNight = price,
                        RoomNumber = roomNumber
                    };
                    if (_roomService.AddRoom(createRoomDto))
                        Console.WriteLine("Room Added Successfully");
                    else
                    {
                        Console.WriteLine("Error on add room");
                    }
                    Console.ReadKey();
                    break;

                }
                else if (currentUser.Role == HotelReservation.Domain.Enums.Roles.NormalUser)
                {
                    Console.WriteLine("View Reservation");
                    var reservations = _reservationService.GetAllReservationByUser(currentUser.Id);
                    if (reservations.Count > 0)
                    {
                        foreach (var r in reservations)
                        {
                            Console.WriteLine($"Room id :{r.RoomId} from {r.CheckInDate} to {r.CheckOutDate} -> status : {r.Status} {r.CreatedAt}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Empty");
                    }
                    Console.ReadKey();
                    break;
                }
                else if (currentUser.Role == HotelReservation.Domain.Enums.Roles.Receptionist)
                {
                    Console.Clear();
                    Console.WriteLine("Reserve room");

                    var users = _userService.GetAll();
                    if (users.Count > 0)
                    {
                        foreach (var u in users)
                        {
                            Console.WriteLine($"{u.Id} -> {u.UserName}");
                        }
                    }
                    Console.WriteLine("Select For which user?");
                    int userId = int.Parse(Console.ReadLine());

                    if (!_userService.IsExistUser(userId))
                    {
                        Console.WriteLine("User Not Found");
                        Console.ReadKey();
                        continue;
                    }

                    var rooms = _roomService.GetAllRoom();
                    if (rooms.Count > 0)
                    {
                        foreach (var r in rooms)
                        {
                            Console.WriteLine($"Id: {r.Id} Room number :{r.RoomNumber} {r.Capacity} {r.PricePerNight}\n" +
                                $" {(r.HasAirConditioner ? "Has Air Conditioner" : "Without Air Conditioner")} \n" +
                                $"{(r.HasWifi ? "Has WIFI" : "Dosn't have WIFI")} \n" +
                                $"{r.Description}");
                        }
                    }
                    Console.WriteLine("Select Room Id");
                    int roomId = Int32.Parse(Console.ReadLine());
                    if (!_roomService.IsExistRoom(roomId))
                    {
                        Console.WriteLine("Invalid room id!");
                        Console.ReadKey();
                        continue;
                    }
                    CreateReservationDto dto = new CreateReservationDto
                    {
                        CheckInDate = HelperMethods.GetDateFromUser(),
                        CheckOutDate = HelperMethods.GetDateFromUser(),
                        RoomId = roomId,
                        Status = HotelReservation.Domain.Enums.Status.Pending,
                        UserId = userId,
                    };
                    var reserveRes = _reservationService.CreateReservation(dto);
                    if (reserveRes.IsSuccess)
                    {
                        if (_reservationService.UpdateStatus(reserveRes.ReserveId, HotelReservation.Domain.Enums.Status.Confirmed))
                            Console.WriteLine("Reserved Successfully!");
                        else
                        {
                            Console.WriteLine("Error on update Status");
                        }
                    }
                    else
                    {
                        Console.WriteLine(reserveRes.Message);
                    }
                    Console.ReadKey();
                    break;
                }
                else if (choice1 == 0)
                    innerFlag = false;
            } while (innerFlag);
        }
        else
        {
            Console.WriteLine(res.ErrorMessage);
        }
        Console.ReadKey();
    }
} while (outerFlag);
