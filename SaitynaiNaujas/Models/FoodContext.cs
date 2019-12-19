using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaitynaiNaujas.Models
{
    public class FoodContext : DbContext
    {
        //add-migration SaitynaiNaujas.Models.FoodContext
        //update-database

        //dotnet ef migrations add InitialCreate
        //dotnet ef database update
        //Add-Migration InitialCreate
        //Update-Database

        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }

        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodCategory>().ToTable("FoodCategory");
            modelBuilder.Entity<FoodItem>().ToTable("FoodItem");
            modelBuilder.Entity<CartItem>().ToTable("CartItem");
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");

            //modelBuilder.Entity<Cart>().HasKey(c => c.Id);
            //modelBuilder.Entity<User>().HasKey(c => c.Id);
            //modelBuilder.Entity<CartItem>().HasKey(c => c.Id);
            //modelBuilder.Entity<FoodItem>().HasKey(c => c.Id);
            //modelBuilder.Entity<FoodCategory>().HasKey(c => c.Id);
            //modelBuilder.Entity<UserLogin>().HasKey(c => c.Id);

            //modelBuilder.Entity<User>().HasOne(c => c.userLogin).WithOne(cc => cc.User).HasForeignKey<User>();
            //modelBuilder.Entity<User>().HasMany(c => c.carts).WithOne(cc => cc.user).HasForeignKey(ccc => ccc.Id);
            //modelBuilder.Entity<Cart>().HasMany(c => c.cartItems).WithOne(cc => cc.cart).HasForeignKey(ccc => ccc.Id);
            //modelBuilder.Entity<CartItem>().OwnsOne(c => c.foodItem)/*.HasForeignKey(ccc => ccc.Id)*/;
            //modelBuilder.Entity<FoodItem>().OwnsMany(c => c.categories)/*.HasForeignKey(ccc => ccc.Id)*/;

            //modelBuilder.Entity<User>().HasOne(c => c.userLogin).WithOne(cc => cc.user).HasForeignKey<User>();
            //modelBuilder.Entity<User>().HasMany(c => c.carts).WithOne(cc => cc.user).HasForeignKey(ccc => ccc.Id);
            //modelBuilder.Entity<Cart>().HasMany(c => c.cartItems).WithOne(cc => cc.cart).HasForeignKey(ccc => ccc.Id);
            //modelBuilder.Entity<CartItem>().OwnsOne(c => c.foodItem)/*.HasForeignKey(ccc => ccc.Id)*/;
            //modelBuilder.Entity<FoodItem>().OwnsMany(c => c.categories)/*.HasForeignKey(ccc => ccc.Id)*/;

            //modelBuilder.Entity<CartItem>().OwnsOne(c => c.foodItem);
            //modelBuilder.Entity<User>().HasOne(c => c.Id).WithMany(cc => cc.).HasForeignKey();

            base.OnModelCreating(modelBuilder);
        }

    }
}
