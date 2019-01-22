using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public static class BasketList
    {
        public static List<string> ShoppingItems { get; set; }
        public static List<string> PriceOfItem { get; set; }
        static BasketList()
        {
            ShoppingItems = new List<string>();
            PriceOfItem = new List<string>();

        }
    }
}
