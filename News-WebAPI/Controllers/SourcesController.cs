﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News_WebAPI.Data;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSource(int id, Source source)
        {
            if (id != source.SourceId)
            {
                return BadRequest();
            }

            _context.Entry(source).State = EntityState.Modified;

            try
            {
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

        // POST: api/Sources
        [HttpPost]
        public async Task<ActionResult<Source>> PostSource(Source source)
        {
            _context.Sources.Add(source);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSource", new { id = source.SourceId }, source);
        }

        // DELETE: api/Sources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSource(int id)
        {
            var source = await _context.Sources.FindAsync(id);
            if (source == null)
            {
                return NotFound();
            }

            _context.Sources.Remove(source);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SourceExists(int id)
        {
            return _context.Sources.Any(e => e.SourceId == id);
        }
    }
}
