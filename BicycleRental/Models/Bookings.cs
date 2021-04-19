using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Models
{
    public class Bookings
    {
        public Bookings()
        {

        }

        public Bookings(int customerId, int bicycleId, string dateRented, string dateReturn)
        {
            this.Customer_Id = customerId;
            this.Bicycle_Id = bicycleId;
            this.Date_Rented = dateRented;
            this.Date_Return = dateReturn;
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("customers.id")]
        public int Customer_Id { get; set; }

        [ForeignKey("bicycle.id")]
        public int Bicycle_Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Date_Rented { get; set; }

        [Required]
        [MaxLength(255)]
        public string Date_Return { get; set; }
    }
}
