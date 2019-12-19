using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SaitynaiNaujas.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }
    }
}
