using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News_WebAPI.Data;
using News_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;


namespace News_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly NewsServerContext _context;

        public AuthorsController(NewsServerContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        //[Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.Where(x => x.StateId == 1).ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.Where(x => x.AuthorId == id && x.StateId == 1).SingleOrDefaultAsync();

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        [HttpPut()]
        [AllowAnonymous]
        public async Task<IActionResult> PutAuthor(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;

            try
            {
                var author_ = await _context.Authors.Where(x => x.AuthorId == author.AuthorId).FirstOrDefaultAsync();

                author_.Name = author.Name ?? author_.Name;
                author_.LastName = author.LastName ?? author_.LastName;
                author_.StateId = 1;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(author.AuthorId))
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

        // POST: api/Authors
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            var author_ = new Author
            {
                Name = author.Name,
                LastName = author.LastName,
                StateId = 1,
                UserId = author.UserId
            };

            _context.Authors.Add(author_);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author_.AuthorId }, author_);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author_ = await _context.Authors.Where(x => x.AuthorId == id).FirstOrDefaultAsync();

                author_.StateId = 2;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
