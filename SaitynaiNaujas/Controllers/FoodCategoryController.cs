using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaitynaiNaujas.Models;

namespace SaitynaiNaujas.Controllers
{
    [Route("api/FoodCategory")]
    public class FoodCategoryController : ControllerBase
    {
        private readonly FoodContext _context;

        public FoodCategoryController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/FoodCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodCategory>>> GetFoodCategories()
        {
            return await _context.FoodCategories.ToListAsync();
        }

        // GET: api/FoodCategory/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<FoodCategory>> GetFoodCategory(int Id)
        {
            var foodCategory = await _context.FoodCategories.FindAsync(Id);

            if (foodCategory == null)
            {
                return NotFound();
            }
            return foodCategory;
        }

        // POST: api/FoodCategory
        [HttpPost]
        public async Task<ActionResult<FoodCategory>> PostFoodCategory([FromBody]FoodCategory item)
        {
            //Sets the correct Id
            //while (_context.FoodCategories.Contains(item) || item.Id == 0)
            //{
            //    item.Id++;
            //}

            _context.FoodCategories.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFoodCategory), new { Id = item.Id, name = item.Name }, item);
        }

        // PUT: api/FoodCategory/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutFoodCategory(int Id, [FromBody]FoodCategory item)
        {
            if (Id != item.Id)
            {
                return BadRequest();
            }
            if (!_context.FoodCategories.Contains(item))
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/foodCategory/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFoodCategory(int Id)
        {
            var foodCategory = await _context.FoodCategories.FindAsync(Id);

            if (foodCategory == null)
            {
                return NotFound();
            }

            _context.FoodCategories.Remove(foodCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
