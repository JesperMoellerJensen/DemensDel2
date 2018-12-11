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
    public class TrainingSessionsController : ControllerBase
    {
        private readonly DemensDbContext _context;

        public TrainingSessionsController(DemensDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainingSessions
        [HttpGet]
        public IEnumerable<TrainingSession> GetTrainingSessions()
        {
            return _context.TrainingSessions;
        }

        // GET: api/TrainingSessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trainingSession = await _context.TrainingSessions.FindAsync(id);

            if (trainingSession == null)
            {
                return NotFound();
            }

            return Ok(trainingSession);
        }

        // GET: api/TrainingSessions/log/5
        [HttpGet("log/{id}")]
        public IEnumerable<TrainingSession> GetTrainingSessionsFromUserId([FromRoute] int id)
        {
            List<TrainingSession> trainingSessions = _context.TrainingSessions.Where(l => l.User.Id == id).ToList();

            return trainingSessions;
        }

        // PUT: api/TrainingSessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingSession([FromRoute] int id, [FromBody] TrainingSession trainingSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingSession.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingSessionExists(id))
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

        // POST: api/TrainingSessions
        [HttpPost]
        public async Task<IActionResult> PostTrainingSession([FromBody] TrainingSession trainingSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrainingSessions.Add(trainingSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingSession", new { id = trainingSession.Id }, trainingSession);
        }

        // DELETE: api/TrainingSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession == null)
            {
                return NotFound();
            }

            _context.TrainingSessions.Remove(trainingSession);
            await _context.SaveChangesAsync();

            return Ok(trainingSession);
        }

        private bool TrainingSessionExists(int id)
        {
            return _context.TrainingSessions.Any(e => e.Id == id);
        }
    }
}