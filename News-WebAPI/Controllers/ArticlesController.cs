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

namespace News_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly NewsServerContext _context;

        public ArticlesController(NewsServerContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            var articles_ = await (from articles in _context.Articles
                                   join authors in _context.Authors
                                   on articles.AuthorId equals authors.AuthorId
                                   join category in _context.Categories
                                   on articles.CategoryId equals category.CategoryId
                                   join source in _context.Sources
                                   on articles.SourceId equals source.SourceId
                                   select new
                                   {                                       
                                       articles.ArticleId,
                                       Source = source.NameSource,
                                       Author = authors.Name + " " + authors.LastName,
                                       articles.Title,
                                       articles.Description,
                                       articles.Content,
                                       articles.UrltoArticle,
                                       articles.UrltoImage,
                                       articles.PublishedAt,
                                       Category = category.Name,
                                       articles.StateId
                                   }).Where(x => x.StateId == 1).ToListAsync();
            return Ok(articles_);
        }

        // GET: api/Articles/5
        [HttpGet("{q}")]
        [AllowAnonymous]
        public async Task<ActionResult<Article>> GetArticle(string q)
        {
            var article_ = await (from articles in _context.Articles
                                  join authors in _context.Authors
                                  on articles.AuthorId equals authors.AuthorId
                                  join category in _context.Categories
                                  on articles.CategoryId equals category.CategoryId
                                  join source in _context.Sources
                                  on articles.SourceId equals source.SourceId
                                  select new
                                  {
                                      articles.ArticleId,
                                      Source = source.NameSource,
                                      Author = authors.Name + " " + authors.LastName,
                                      articles.Title,
                                      articles.Description,
                                      articles.Content,
                                      articles.UrltoArticle,
                                      articles.UrltoImage,
                                      articles.PublishedAt,
                                      Category = category.Name
                                  }).FirstOrDefaultAsync(x => x.Title.Contains(q));

            if (article_ == null)
            {
                return NotFound();
            }

            return Ok(article_);
        }


        // PUT: api/Articles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Article article)
        {
            if (id != article.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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

        // POST: api/Articles
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.ArticleId }, article);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
