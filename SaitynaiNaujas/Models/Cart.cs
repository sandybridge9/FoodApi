using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SaitynaiNaujas.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public List<CartItem> CartItems { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
