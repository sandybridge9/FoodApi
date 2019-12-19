using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaitynaiNaujas.Models;

namespace SaitynaiNaujas.Controllers
{
    [Route("api/FoodItem")]
    public class FoodItemController : ControllerBase
    {
        private readonly FoodContext _context;

        public FoodItemController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/FoodItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            return await _context.FoodItems
                .Include(fi => fi.FoodCategory)
                .ToListAsync();
        }

        // GET: api/FoodItem/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<FoodItem>> GetFoodItem(int Id)
        {
            //var foodItem = await _context.FoodItems.FindAsync(Id);
            var foodItem = await _context.FoodItems
                .Include(fi => fi.FoodCategory)
                .FirstOrDefaultAsync(fi => fi.Id == Id);

            if (foodItem == null)
            {
                return NotFound();
            }
            return foodItem;
        }

        // POST: api/FoodItem
        [HttpPost]
        public async Task<ActionResult<FoodItem>> PostFoodItem([FromBody]FoodItem item)
        {
            _context.FoodItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFoodItem), new { Id = item.Id, name = item.Name }, item);
        }

        // PUT: api/FoodItem/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutFoodItem(int Id, [FromBody]FoodItem item)
        {
            if (Id != item.Id)
            {
                return BadRequest();
            }
            if (!_context.FoodItems.Contains(item))
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/FoodItem/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFoodItem(int Id)
        {
            var foodItem = await _context.FoodItems.FindAsync(Id);

            if (foodItem == null)
            {
                return NotFound();
            }

            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //GET: api/FoodItem/1/FoodCategories
        [HttpGet("{Id}/FoodCategory")]
        public async Task<ActionResult<FoodCategory>> GetFoodItemCategories(int Id)
        {
            var foodItem = await _context.FoodItems
                .Include(fi => fi.FoodCategory)
                .FirstOrDefaultAsync(i => i.Id == Id);

            if (foodItem == null)
            {
                return NotFound();
            }

            var foodCategory = foodItem.FoodCategory;

            if (foodCategory == null)
            {
                return NotFound();
            }

            return foodCategory;
        }
    }
}
