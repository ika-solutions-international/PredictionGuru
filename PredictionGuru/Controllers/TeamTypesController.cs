using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PredictionGuru.DataContext;
using PredictionGuru.Models;

namespace PredictionGuru.Controllers
{
    [Produces("application/json")]
    [Route("api/TeamTypes")]
    public class TeamTypesController : Controller
    {
        private readonly PredictionGuruContext _context;

        public TeamTypesController(PredictionGuruContext context)
        {
            _context = context;
        }

        // GET: api/TeamTypes
        [HttpGet]
        public IEnumerable<TeamType> GetTeamType()
        {
            return _context.TeamType;
        }

        // GET: api/TeamTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamType = await _context.TeamType.SingleOrDefaultAsync(m => m.Id == id);

            if (teamType == null)
            {
                return NotFound();
            }

            return Ok(teamType);
        }

        // PUT: api/TeamTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamType([FromRoute] int id, [FromBody] TeamType teamType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamType.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamTypeExists(id))
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

        // POST: api/TeamTypes
        [HttpPost]
        public async Task<IActionResult> PostTeamType([FromBody] TeamType teamType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TeamType.Add(teamType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamType", new { id = teamType.Id }, teamType);
        }

        // DELETE: api/TeamTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamType = await _context.TeamType.SingleOrDefaultAsync(m => m.Id == id);
            if (teamType == null)
            {
                return NotFound();
            }

            _context.TeamType.Remove(teamType);
            await _context.SaveChangesAsync();

            return Ok(teamType);
        }

        private bool TeamTypeExists(int id)
        {
            return _context.TeamType.Any(e => e.Id == id);
        }
    }
}