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
    public class ExerciseResultsController : ControllerBase
    {
        private readonly DemensDbContext _context;

        public ExerciseResultsController(DemensDbContext context)
        {
            _context = context;
        }

        // GET: api/ExerciseResults
        [HttpGet]
        public IEnumerable<ExerciseResult> GetExerciseResults()
        {
            return _context.ExerciseResults;
        }

        // GET: api/ExerciseResults/5
        [HttpGet("{id}")]
        public ExerciseResult GetExerciseResult([FromRoute] int id)
        {
           Exercise exercise = _context.Exercises.Single(x => x.Id == id);
           return _context.ExerciseResults.Single(x => x.Exercise == exercise);  
        }

        // PUT: api/ExerciseResults/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseResult([FromRoute] int id, [FromBody] ExerciseResult exerciseResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseResult.Id)
            {
                return BadRequest();
            }

            _context.Entry(exerciseResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseResultExists(id))
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

        // POST: api/ExerciseResults
        [HttpPost]
        public async Task<IActionResult> PostExerciseResult([FromBody] ExerciseResult exerciseResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExerciseResults.Add(exerciseResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExerciseResult", new { id = exerciseResult.Id }, exerciseResult);
        }

        // DELETE: api/ExerciseResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseResult([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exerciseResult = await _context.ExerciseResults.FindAsync(id);
            if (exerciseResult == null)
            {
                return NotFound();
            }

            _context.ExerciseResults.Remove(exerciseResult);
            await _context.SaveChangesAsync();

            return Ok(exerciseResult);
        }

        private bool ExerciseResultExists(int id)
        {
            return _context.ExerciseResults.Any(e => e.Id == id);
        }
    }
}