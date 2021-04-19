using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Models
{
    public class Bicycles
    {
        public Bicycles()
        {

        }

        public Bicycles(string name, bool available, int price, int storeId)
        {
            this.Bicycle_name = name;
            this.Available = available;
            this.Price = price;
            this.Store_Id = storeId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Bicycle_name { get; set; }

        [Required]
        public bool Available { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Store_Id { get; set; }
    }
}
