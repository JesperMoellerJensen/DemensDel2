using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemensDel2.Models;
using DemensDel2API.DataAccess;

namespace DemensDel2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseTypesController : ControllerBase
    {
        private readonly DemensDbContext _context;

        public ExerciseTypesController(DemensDbContext context)
        {
            _context = context;
        }

        // GET: api/ExerciseTypes
        [HttpGet]
        public IEnumerable<ExerciseType> GetExerciseTypes()
        {
            return _context.ExerciseTypes;
        }

        // GET: api/ExerciseTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exerciseType = await _context.ExerciseTypes.FindAsync(id);

            if (exerciseType == null)
            {
                return NotFound();
            }

            return Ok(exerciseType);
        }

        // PUT: api/ExerciseTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseType([FromRoute] int id, [FromBody] ExerciseType exerciseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseType.Id)
            {
                return BadRequest();
            }

            _context.Entry(exerciseType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseTypeExists(id))
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

        // POST: api/ExerciseTypes
        [HttpPost]
        public async Task<IActionResult> PostExerciseType([FromBody] ExerciseType exerciseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExerciseTypes.Add(exerciseType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExerciseType", new { id = exerciseType.Id }, exerciseType);
        }

        // DELETE: api/ExerciseTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exerciseType = await _context.ExerciseTypes.FindAsync(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            _context.ExerciseTypes.Remove(exerciseType);
            await _context.SaveChangesAsync();

            return Ok(exerciseType);
        }

        private bool ExerciseTypeExists(int id)
        {
            return _context.ExerciseTypes.Any(e => e.Id == id);
        }
    }
}