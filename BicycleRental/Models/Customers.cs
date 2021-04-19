using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Models
{
    public class Customers
    {
        public Customers()
        {

        }

        public Customers(string firstName, string lastName, string email, string phone)
        {
            this.First_Name = firstName;
            this.Last_Name = lastName;
            this.Email = email;
            this.Phone = phone;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string First_Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Last_Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Phone { get; set; }
    }
}
