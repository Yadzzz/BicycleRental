using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shop
{
    public static class Data
    {
        public static void DataCheck()
        {
            if(Environment.BikeShopContext.Stores.Count() == 0 && Environment.BikeShopContext.Bicycles.Count() == 0)
            {
                insertData();
            }
        }

        private static void insertData()
        {
            var store1 = new Models.Stores("Johans bikeshop", "Sisjöngatan 23");
            var store2 = new Models.Stores("Oscars bikeshop", "Kullegatan 99");
            Environment.BikeShopContext.Stores.Add(store1);
            Environment.BikeShopContext.Stores.Add(store2);
            Environment.BikeShopContext.SaveChanges();
            Environment.BikeShopContext.Bicycles.Add(new Models.Bicycles("BMX", true, 500, store1.Id));
            Environment.BikeShopContext.Bicycles.Add(new Models.Bicycles("Mountain Bike", true, 1000, store1.Id));
            Environment.BikeShopContext.Bicycles.Add(new Models.Bicycles("Electrical Bike", true, 1200, store2.Id));
            Environment.BikeShopContext.Bicycles.Add(new Models.Bicycles("Racing Bike", true, 1000, store2.Id));
            Environment.BikeShopContext.Bicycles.Add(new Models.Bicycles("Prone Bike", true, 1000, store2.Id));
            Environment.BikeShopContext.SaveChanges();
        }
    }
}
