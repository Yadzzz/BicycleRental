using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Models
{
    public class Stores
    {
        public Stores()
        {

        }

        public Stores(string storeName, string adress)
        {
            this.Store_Name = storeName;
            this.Adress = adress;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Store_Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Adress { get; set; }
    }
}
