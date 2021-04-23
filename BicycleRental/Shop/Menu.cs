using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shop
{
    public class Menu
    {
        public delegate void MenuSection();
        public Dictionary<int, MenuSection> MenuSections;

        public Menu()
        {
            this.MenuSections = new Dictionary<int, MenuSection>();
            this.MenuSections.Add(1, this.RegisterCustomer);
            this.MenuSections.Add(2, this.CreateBooking);
            this.MenuSections.Add(3, this.ShowBicycles);
            this.MenuSections.Add(4, this.ShowBookings);
            this.MenuSections.Add(5, this.RemoveBooking);
            this.MenuSections.Add(6, this.ChangeReturnDate);
        }

        /// <summary>
        /// Registers a customer
        /// </summary>
        public void RegisterCustomer()
        {
            Console.WriteLine("First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Phone Number: ");
            string phone = Console.ReadLine();

            var customer = new Models.Customers(firstName, lastname, email, phone);
            Environment.BikeShopContext.Customers.Add(customer);
            Environment.BikeShopContext.SaveChanges();
            Environment.CustomerId = customer.Id;

            Console.WriteLine("Customer Registered");
        }

        /// <summary>
        /// Creates a booking for current customer
        /// </summary>
        public void CreateBooking()
        {
            this.ShowBicycles();

            Console.WriteLine("Enter bike Id:");
            if(int.TryParse(Console.ReadLine(), out int bikeId))
            {
                var bike = Environment.BikeShopContext.Bicycles.Where(x => x.Id == bikeId).FirstOrDefault();
                if (bike != null)
                {
                    var booking = new Models.Bookings(Environment.CustomerId, bikeId, DateTime.Now.ToString(), DateTime.Now.AddDays(5).ToString());
                    Environment.BikeShopContext.Bookings.Add(booking);
                    Environment.BikeShopContext.SaveChanges();
                    Environment.BikeShopContext.Bookings_Items.Add(new Models.Bookings_Items(booking.Id, bikeId, bike.Store_Id));
                    bike.Available = false;
                    Environment.BikeShopContext.SaveChanges();
                    Console.WriteLine("Booking created");
                }
                else
                {
                    Console.WriteLine("Could not find Bike Id");
                }
            }
            else
            {
                Console.WriteLine("Input is not numeric, please try again");
            }
        }

        /// <summary>
        /// Shows all bookings for current customer
        /// </summary>
        public void ShowBookings()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var booking in Environment.BikeShopContext.Bookings.Where(x => x.Customer_Id == Environment.CustomerId))
            {
                stringBuilder.AppendLine("Bicycle Id : " + booking.Bicycle_Id.ToString());
                stringBuilder.AppendLine("Rental date : " + booking.Date_Rented);
                stringBuilder.AppendLine("Return date: " + booking.Date_Return);
            }
        }

        /// <summary>
        /// Shows all available bicycles
        /// </summary>
        public void ShowBicycles()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var bike in Environment.BikeShopContext.Bicycles.Where(x => x.Available == true))
            {
                stringBuilder.AppendLine("Id: " + bike.Id);
                stringBuilder.AppendLine("Name: " + bike.Bicycle_name);
                stringBuilder.AppendLine("Price: " + bike.Price);
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        /// <summary>
        /// Removes a booking
        /// </summary>
        public void RemoveBooking()
        {
            this.ShowBookings();

            Console.WriteLine("Booking Id: ");
            if(int.TryParse(Console.ReadLine(), out int bookingId))
            {
                var booking = Environment.BikeShopContext.Bookings.Where(x => x.Id == bookingId).FirstOrDefault();

                if (booking.Customer_Id != Environment.CustomerId)
                {
                    Console.WriteLine("You cannot remove another customers booking");
                    return;
                }

                foreach(var bookingItem in Environment.BikeShopContext.Bookings_Items.Where(x => x.Booking_Id == booking.Id).ToList())
                {
                    Environment.BikeShopContext.Bicycles.Where(x => x.Id == bookingItem.Bicycle_Id).FirstOrDefault().Available = true;
                    Environment.BikeShopContext.Bookings_Items.Remove(bookingItem);
                }

                Environment.BikeShopContext.Bookings.Remove(booking);
                Environment.BikeShopContext.SaveChanges();

                Console.WriteLine("Booking removed");
            }
            else
            {
                Console.WriteLine("Input is not numeric, please try again.");
            }
        }

        /// <summary>
        /// Changes the return date of an existing booking
        /// </summary>
        public void ChangeReturnDate()
        {
            Console.WriteLine("Booking Id: ");
            if (int.TryParse(Console.ReadLine(), out int bookingId))
            {
                var booking = Environment.BikeShopContext.Bookings.Where(x => x.Id == bookingId).FirstOrDefault();

                if (booking.Customer_Id != Environment.CustomerId)
                {
                    Console.WriteLine("You cannot change another customers booking");
                    return;
                }

                Console.WriteLine("How many days would you like to extend the rental date with?");
                if (int.TryParse(Console.ReadLine(), out int days))
                {
                    DateTime newReturnDate = Convert.ToDateTime(booking.Date_Return);
                    booking.Date_Return = newReturnDate.AddDays(days).ToString();
                    Environment.BikeShopContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Input is not numeric, please try again.");
                }

                Console.WriteLine("Return date changed");
            }
            else
            {
                Console.WriteLine("Input is not numeric, please try again.");
            }
        }
    }
}
