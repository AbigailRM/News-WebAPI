using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using News_WebAPI.Models;

namespace News_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcesController : ControllerBase
    {
        private readonly NewsServerContext _context;

        public SourcesController(NewsServerContext context)
        {
            _context = context;
        }

        // GET: api/Sources
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Source>>> GetSources()
        {
            return await _context.Sources.ToListAsync();
        }

        // GET: api/Sources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Source>> GetSource(int id)
        {
            var source = await _context.Sources.FindAsync(id);

            if (source == null)
            {
                return NotFound();
            }

            return source;
        }

        // PUT: api/Sources/5
        [HttpPut()]
        [AllowAnonymous]
        public async Task<IActionResult> PutSource(Source source)
        {
            _context.Entry(source).State = EntityState.Modified;

            try
            {
                var source_ = await _context.Sources.Where(x => x.SourceId == source.SourceId).FirstOrDefaultAsync();

                source_.SourceName = source.SourceName ?? source_.SourceName;
                source_.StateId = 1;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SourceExists(source.SourceId))
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

        // POST: api/Sources
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Source>> PostSource(Source source)
        {
            var source_ = new Source
            {
                SourceName = source.SourceName,
                StateId = 1
            };

            _context.Sources.Add(source_);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSource", new { id = source_.SourceId }, source_);
        }

        // DELETE: api/Sources/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteSource(int id)
        {
            try
            {
                var source_ = await _context.Sources.Where(x => x.SourceId == id).FirstOrDefaultAsync();

                source_.StateId = 2;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SourceExists(id))
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

        private bool SourceExists(int id)
        {
            return _context.Sources.Any(e => e.SourceId == id);
        }
    }
}
