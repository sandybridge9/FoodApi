using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaitynaiNaujas.Models;

namespace SaitynaiNaujas.Controllers
{
    [Route("api/CartItem")]
    public class CartItemController : ControllerBase
    {
        private readonly FoodContext _context;

        public CartItemController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/CartItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.CartItems
                //.Include(ci => ci.Cart)
                .Include(ci => ci.FoodItem)
                    .ThenInclude(fi => fi.FoodCategory)
                .ToListAsync();
        }

        // GET: api/CartItem/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(int Id)
        {
            var cartItem = await _context.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.FoodItem)
                    .ThenInclude(fi => fi.FoodCategory)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (cartItem == null)
            {
                return NotFound();
            }
            return cartItem;
        }

        // GET: api/CartItem/1/FoodItem
        [HttpGet("{Id}/FoodItem")]
        public async Task<ActionResult<FoodItem>> GetCartItemFoodItem(int Id)
        {
            var cartItem = await _context.CartItems
                .Include(a => a.FoodItem)
                    .ThenInclude(fi => fi.FoodCategory)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (cartItem == null)
            {
                return NotFound();
            }

            var foodItem = cartItem.FoodItem;
            if (foodItem == null)
            {
                return NotFound();
            }

            return foodItem;
        }

        // POST: api/FoodItem
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem([FromBody]CartItem item)
        {
            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCartItem), new { Id = item.Id, Count = item.Count }, item);
        }

        // PUT: api/CartItem/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCartItem(int Id, [FromBody]CartItem item)
        {
            if (Id != item.Id)
            {
                return BadRequest();
            }
            if (!_context.CartItems.Contains(item))
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/CartItem/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCartItem(int Id)
        {
            var cartItem = await _context.CartItems.FindAsync(Id);

            if (cartItem == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
