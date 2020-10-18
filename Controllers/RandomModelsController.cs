using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotNET_Chat_Server.Data;
using dotNET_Chat_Server.Models;

namespace dotNET_Chat_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RandomModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RandomModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RandomModel>>> GetRandomModels()
        {
            return await _context.RandomModels.ToListAsync();
        }

        // GET: api/RandomModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RandomModel>> GetRandomModel(Guid id)
        {
            var randomModel = await _context.RandomModels.FindAsync(id);

            if (randomModel == null)
            {
                return NotFound();
            }

            return randomModel;
        }

        // PUT: api/RandomModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRandomModel(Guid id, RandomModel randomModel)
        {
            if (id != randomModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(randomModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RandomModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RandomModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RandomModel>> PostRandomModel(RandomModel randomModel)
        {
            _context.RandomModels.Add(randomModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRandomModel", new { id = randomModel.Id }, randomModel);
        }

        // DELETE: api/RandomModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RandomModel>> DeleteRandomModel(Guid id)
        {
            var randomModel = await _context.RandomModels.FindAsync(id);
            if (randomModel == null)
            {
                return NotFound();
            }

            _context.RandomModels.Remove(randomModel);
            await _context.SaveChangesAsync();

            return randomModel;
        }

        private bool RandomModelExists(Guid id)
        {
            return _context.RandomModels.Any(e => e.Id == id);
        }
    }
}
