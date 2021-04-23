using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental
{
    public class ConsoleHandler
    {
        private StringBuilder stringBuilder;
        public ConsoleHandler()
        {
            this.stringBuilder = new StringBuilder();
            this.stringBuilder.AppendLine("Welcome!");
            this.stringBuilder.AppendLine("Enter 1 to register a customer");
            this.stringBuilder.AppendLine("Enter 2 to create a booking");
            this.stringBuilder.AppendLine("Enter 3 to show all available Bicycles");
            this.stringBuilder.AppendLine("Enter 4 to show your bookings");
            this.stringBuilder.AppendLine("Enter 5 to remove a booking");
            this.stringBuilder.AppendLine("Enter 6 to change return date of a bicycle");
        }

        /// <summary>
        /// Shows menu for user
        /// </summary>
        public void InitializeMenu()
        {
            Console.WriteLine(stringBuilder);

            if (int.TryParse(Console.ReadLine(), out int menuNum))
            {
                inputHandler(menuNum);
            }
            else
            {
                Console.WriteLine("Input is not numeric, please try again.");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Handles user input
        /// </summary>
        /// <param name="input">User input</param>
        private static void inputHandler(int input)
        {
            if (Environment.MainMenu.MenuSections.TryGetValue(input, out var menuSection))
            {
                if (input != 1 && Environment.CustomerId == 0)
                {
                    Console.WriteLine("You need to register as a customer to perform this action.");
                    return;
                }
                else if(input == 1 && Environment.CustomerId > 0)
                {
                    Console.WriteLine("You already has registered as a customer.");
                    return;
                }

                menuSection.Invoke();
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        }
    }
}
