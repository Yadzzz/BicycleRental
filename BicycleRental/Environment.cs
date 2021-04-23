using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental
{
    public static class Environment
    {
        public static Data.BikeShopContext BikeShopContext { get; set; }
        public static Shop.Menu MainMenu { get; set; }
        public static ConsoleHandler ConsoleHandler { get; set; }
        public static int CustomerId { get; set; }

        /// <summary>
        /// Initializes the required objects
        /// </summary>
        public static void Initialize()
        {
            BikeShopContext = new Data.BikeShopContext();
            MainMenu = new Shop.Menu();
            ConsoleHandler = new ConsoleHandler();

            Shop.Data.DataCheck();

            while (true)
            {
                ConsoleHandler.InitializeMenu();
            }
        }
    }
}
