using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaitynaiNaujas.Models;

namespace SaitynaiNaujas.Controllers
{
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly FoodContext _context;

        public UserController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetUser(int Id)
        {
            var user = await _context.Users
                .Include(u => u.Carts)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // GET: api/User/1/Carts
        [HttpGet("{Id}/Carts")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetUserCarts(int Id)
        {
            var user = await _context.Users
                .Include(u => u.Carts)
                    .ThenInclude(c => c.CartItems)
                        .ThenInclude(ci => ci.FoodItem)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (user == null)
            {
                return NotFound();
            }

            var userCarts = user.Carts;

            if (userCarts == null)
            {
                return NotFound();
            }

            var userCartsList = new List<Cart>();
            foreach (var uc in userCarts)
            {
                userCartsList.Add(uc);
            }

            return userCartsList;
        }

        // GET: api/User/1/Carts/1
        [HttpGet("{Id}/Carts/{Id2}")]
        public async Task<ActionResult<Cart>> GetUserCart(int Id, int Id2)
        {
            var user = await _context.Users
                .Include(u => u.Carts)
                    .ThenInclude(c => c.CartItems)
                        .ThenInclude(ci => ci.FoodItem)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (user == null)
            {
                return NotFound();
            }

            var userCarts = user.Carts;

            if (userCarts[Id2] == null)
            {
                return NotFound();
            }

            Cart cart = userCarts[Id2];

            return cart;
        }

        // GET: api/User/1/Carts/1/CartItem/1
        [HttpGet("{Id}/Carts/{Id2}/CartItem/{Id3}")]
        public async Task<ActionResult<CartItem>> GetUserCart(int Id, int Id2, int Id3)
        {
            var user = await _context.Users
                .Include(u => u.Carts)
                    .ThenInclude(c => c.CartItems)
                        .ThenInclude(ci => ci.FoodItem)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (user == null)
            {
                return NotFound();
            }

            var userCarts = user.Carts;

            if (userCarts[Id2] == null)
            {
                return NotFound();
            }

            Cart cart = userCarts[Id2];

            if (cart.CartItems[Id3] == null)
            {
                return NotFound();
            }

            CartItem cartItem = cart.CartItems[Id3];

            return cartItem;
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody]User item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { Id = item.Id, name = item.Name }, item);
        }

        // PUT: api/User/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutUser(int Id, [FromBody]User item)
        {
            if (Id != item.Id)
            {
                return BadRequest();
            }
            if (!_context.Users.Contains(item))
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = await _context.Users.FindAsync(Id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
