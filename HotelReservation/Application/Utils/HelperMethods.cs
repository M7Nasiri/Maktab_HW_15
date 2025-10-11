using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Utils
{
    public class HelperMethods
    {
        public static DateTime GetDateFromUser()
        {
            DateTime date;
            string userInput;
            Console.WriteLine("Enter DateTime in format dd/MM/yyyy");
            while (true)
            {
                userInput = Console.ReadLine();
                if (DateTime.TryParseExact(userInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please use dd/MM/yyyy format.");
                }
            }
        }
    }
}
