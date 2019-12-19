using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaitynaiNaujas.Models;

namespace SaitynaiNaujas.Data
{
    public class DbInitializer
    {
        public static void Initialize(FoodContext context)
        {
            context.Database.EnsureCreated();

            // Look for any FoodCategories.
            if (context.FoodCategories.Any())
            {
                return;   // DB has been seeded
            }

            var foodCategories = new FoodCategory[]
            {
                new FoodCategory{Name="Vegetable"},
                new FoodCategory{Name="Fruit"},
                new FoodCategory{Name="Product"},
                new FoodCategory{Name="Sauce"},
                new FoodCategory{Name="Meat"},
                new FoodCategory{Name="Fish"},
                new FoodCategory{Name="Seafood"},
                new FoodCategory{Name="CannedGoods"},
                new FoodCategory{Name="Sweets"}
            };
            foreach (FoodCategory fc in foodCategories)
            {
                context.FoodCategories.Add(fc);
            }
            context.SaveChanges();

            var foodItems = new FoodItem[]
            {
                new FoodItem{Name="Cucumber", FoodCategoryId=1},
                new FoodItem{Name="Apple", FoodCategoryId=2},
                new FoodItem{Name="Twix", FoodCategoryId=3},
                new FoodItem{Name="Ketchup", FoodCategoryId=4},
                new FoodItem{Name="Poultry", FoodCategoryId=5},
                new FoodItem{Name="Salmon", FoodCategoryId=6},
                new FoodItem{Name="Shrimp", FoodCategoryId=7},
                new FoodItem{Name="Canned Peaches", FoodCategoryId=8},
                new FoodItem{Name="Nomeda", FoodCategoryId=9}
            };
            foreach (FoodItem fi in foodItems)
            {
                context.FoodItems.Add(fi);
            }
            context.SaveChanges();

            var userLogins = new UserLogin[]
            {
                new UserLogin{Username = "test", Password = "test", Token = "tokentokentokentoken"},
                new UserLogin{Username = "test2", Password = "test2", Token = "tokentokentokentoken2"}
            };
            foreach (UserLogin ul in userLogins)
            {
                context.UserLogins.Add(ul);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User{Name = "Pranas", UserLoginId = 1},
                new User{Name = "Jonas", UserLoginId = 2}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var carts = new Cart[]
            {
                new Cart{Name = "Cart1", UserId = 1},
                new Cart{Name = "Cart2", UserId = 2}
            };
            foreach (Cart c in carts)
            {
                context.Carts.Add(c);
            }
            context.SaveChanges();

            var cartItems = new CartItem[]
            {
                new CartItem{FoodItemId = 2, CartId = 1, Count = 1},
                new CartItem{FoodItemId = 3, CartId = 2, Count = 1}
            };
            foreach (Cart c in carts)
            {
                context.Carts.Add(c);
            }
            context.SaveChanges();
        }
    }
}
