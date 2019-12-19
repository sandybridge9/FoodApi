using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SaitynaiNaujas.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
