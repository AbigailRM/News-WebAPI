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
        //[Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            var articles_ = await (from articles in _context.Articles
                                   join authors in _context.Authors
                                   on articles.AuthorId equals authors.AuthorId
                                   join category in _context.Categories
                                   on articles.CategoryId equals category.CategoryId
                                   join source in _context.Sources
                                   on articles.SourceId equals source.SourceId
                                   join country in _context.Countries
                                   on articles.CountryId equals country.CountryId
                                   join language in _context.Languages
                                   on articles.LanguageId equals language.LanguageId
                                   select new
                                   {
                                       articles.ArticleId,
                                       Source = source.SourceName,
                                       AutorId = articles.AuthorId,
                                       Author = authors.Name + " " + authors.LastName,
                                       articles.Title,
                                       articles.Description,
                                       articles.Content,
                                       articles.UrltoArticle,
                                       articles.UrltoImage,
                                       articles.PublishedAt,
                                       articles.CategoryId,
                                       CategoryName = category.Name,
                                       articles.CountryId,
                                       CountryCode = country.CountryCode,
                                       CountryName = country.Name,
                                       articles.LanguageId,
                                       LanguageCode = language.LanguageCode,
                                       LanguageName = language.Name,
                                       articles.StateId
                                   }).Where(x => x.StateId == 1).ToListAsync();
            return Ok(articles_);
        }

        // GET: api/Articles/5
        [ActionName(nameof(GetArticle))]
        [HttpGet("{q}")]
        [AllowAnonymous]
        public async Task<ActionResult<Article>> GetArticle(/*[FromQuery]*/ string q = null,/* [FromQuery]*/ string coun = null, /*[FromQuery] */string cat=null, int Id = 0)
        {

            var article_ = await (from articles in _context.Articles
                                  join authors in _context.Authors
                                  on articles.AuthorId equals authors.AuthorId
                                  join category in _context.Categories
                                  on articles.CategoryId equals category.CategoryId
                                  join source in _context.Sources
                                  on articles.SourceId equals source.SourceId
                                  join country in _context.Countries
                                  on articles.CountryId equals country.CountryId
                                  select new
                                  {
                                      articles.ArticleId,
                                      Source = source.SourceName,
                                      AutorId = articles.AuthorId,
                                      Author = authors.Name + " " + authors.LastName,
                                      articles.Title,
                                      articles.Description,
                                      articles.Content,
                                      articles.UrltoArticle,
                                      articles.UrltoImage,
                                      articles.PublishedAt,
                                      CategoryId = category.CategoryId,
                                      CategoryName = category.Name,
                                      CountryId = country.CountryId,
                                      CountryCode = country.CountryCode,

                                  }).FirstOrDefaultAsync(x => q != null ? x.Title.Contains(q): Id != 0? x.ArticleId == Id : coun != null ? x.CountryCode == coun : cat !=null? x.CategoryName == cat: x.Title=="");

                
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
        [AllowAnonymous]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            var _article = new Article
            {
                Title = article.Title,
                AuthorId = article.AuthorId,
                Description = article.Description,
                Content = article.Content,
                UrltoArticle = article.UrltoArticle,
                UrltoImage = article.UrltoImage,
                PublishedAt = article.PublishedAt,
                SourceId = article.SourceId,
                CategoryId = article.CategoryId,
                CountryId = article.CountryId,
                //Country = ,
                LanguageId = article.LanguageId,
                UserId = article.UserId,
                CreateDate = DateTime.Now,
                StateId = 1
            };

            _context.Articles.Add(_article);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticle), new { q = _article.Title}, _article);

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
