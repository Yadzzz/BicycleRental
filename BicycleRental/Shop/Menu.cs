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

        public void RemoveBooking()
        {
            this.ShowBookings();

            Console.WriteLine("Booking Id: ");
            if(int.TryParse(Console.ReadLine(), out int bookingId))
            {
                var booking = Environment.BikeShopContext.Bookings.Where(x => x.Id == bookingId).FirstOrDefault();

                foreach(var bookingItem in Environment.BikeShopContext.Bookings_Items.Where(x => x.Booking_Id == booking.Id))
                {
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

        public void ChangeReturnDate()
        {

        }
    }
}
