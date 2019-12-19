using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaitynaiNaujas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaitynaiNaujas.Controllers
{
    [Route("api/Cart")]
    public class CartController : ControllerBase
    {
        private readonly FoodContext _context;

        public CartController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ToListAsync();
        }

        // GET: api/Cart/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Cart>> GetCart(int Id)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (cart == null)
            {
                return NotFound();
            }
            return cart;
        }

        // GET: api/Cart/1/CartItems
        [HttpGet("{Id}/CartItems")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartCartItems(int Id)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.FoodItem)
                        .ThenInclude(fi => fi.FoodCategory)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (cart == null)
            {
                return NotFound();
            }

            var CartItems = cart.CartItems;

            if (CartItems == null)
            {
                return NotFound();
            }

            var CartItemsList = new List<CartItem>();

            foreach (var cartItem in CartItems)
            {
                CartItemsList.Add(cartItem);
            }

            return CartItemsList;
        }

        // GET: api/Cart/1/CartItems/1
        [HttpGet("{Id}/CartItems/{Id2}")]
        public async Task<ActionResult<CartItem>> GetCartCartItem(int Id, int Id2)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.FoodItem)
                        .ThenInclude(fi => fi.FoodCategory)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (cart == null)
            {
                return NotFound();
            }

            var CartItems = cart.CartItems;

            if (CartItems == null)
            {
                return NotFound();
            }
            CartItem cartItem = new CartItem();
            for (int i = 0; i < Id2; i++)
            {
                cartItem = CartItems[i];
            }

            return cartItem;
        }

        // POST: api/Cart
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart([FromBody]Cart item)
        {
            _context.Carts.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCart), new { Id = item.Id, name = item.Name}, item);
        }

        // PUT: api/Cart/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCart(int Id, [FromBody]Cart item)
        {
            if (Id != item.Id)
            {
                return BadRequest();
            }
            if (!_context.Carts.Contains(item))
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Cart/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCart(int Id)
        {
            var cart = await _context.Carts.FindAsync(Id);

            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
