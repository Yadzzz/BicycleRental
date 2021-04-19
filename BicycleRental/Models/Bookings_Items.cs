using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Models
{
    public class Bookings_Items
    {
        public Bookings_Items()
        {

        }

        public Bookings_Items(int bookingId, int bicycleId, int storeId)
        {
            this.Booking_Id = bookingId;
            this.Bicycle_Id = bicycleId;
            this.Store_Id = storeId;
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("bookings.id")]
        public int Booking_Id { get; set; }

        [ForeignKey("bicycles.id")]
        public int Bicycle_Id { get; set; }

        [ForeignKey("stores.id")]
        public int Store_Id { get; set; }
    }
}
