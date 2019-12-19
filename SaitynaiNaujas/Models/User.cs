using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace SaitynaiNaujas.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserLoginId { get; set; }
        public UserLogin UserLogin { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
