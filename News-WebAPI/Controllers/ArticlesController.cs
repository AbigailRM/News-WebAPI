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
                                   join sort in _context.SortBies
                                   on articles.SortId equals sort.SortId
                                   select new
                                   {
                                       articles.ArticleId,
                                       articles.SourceId,
                                       Source = source.SourceName,
                                       AuthorId = articles.AuthorId,
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
                                       articles.SortId,
                                       Sort = sort.Name,
                                       articles.StateId
                                   }).Where(x => x.StateId == 1).ToListAsync();
            return Ok(articles_);
        }

        // GET: api/Articles/5
        [ActionName(nameof(GetArticle))]
        [HttpGet("Search")]
        //[Route("Article/Get/")]
        [AllowAnonymous]
        public async Task<ActionResult<Article>> GetArticle(/*[FromQuery]*/ string q = "",
            /* [FromQuery]*/ string coun = null, 
            /*[FromQuery] */int cat=0, int Id = 0)
        {

            var article_ = await _context.Articles
                .Include(x => x.Author).Include(x => x.Category)
                .Include(x => x.Source).Include(x => x.Country).FirstOrDefaultAsync(x => q != null ? x.Title.Contains(q) : Id != 0
                                      ? x.ArticleId == Id : coun != null
                                      ? x.Country.CountryCode == coun : cat != 0
                                      ? x.CategoryId == cat : x.Title == "");


            if (article_ == null)
            {
                return NotFound();
            }

            return Ok(article_);

        }


        // PUT: api/Articles/5
        [HttpPut()]
        [AllowAnonymous]
        public async Task<IActionResult> PutArticle(Article article)
        {
           
            //_context.Entry(article).State = EntityState.Modified;

            try
            {
                var article_ = await _context.Articles.Where(x => x.ArticleId == article.ArticleId).FirstOrDefaultAsync<Article>();

                article_.ArticleId = article.ArticleId == 0 ? article_.ArticleId : article.ArticleId;

                article_.Title = article.Title == null ? article_.Title : article.Title;

                article_.AuthorId = article.AuthorId == 0 ? article_.AuthorId : article.AuthorId;

                article_.Description = article.Description == null ? article_.Description : article.Description;

                article_.Content = article.Content == null ? article_.Content : article.Content;

                article_.UrltoArticle = article.UrltoArticle == null ? article_.UrltoArticle : article.UrltoArticle;

                article_.UrltoImage = article.UrltoImage == null ? article_.UrltoImage : article.UrltoImage;

                article_.PublishedAt = article.PublishedAt == null ? article_.PublishedAt : article.PublishedAt;

                article_.SourceId = article.SourceId == 0 ? article_.SourceId : article.SourceId;

                article_.CategoryId = article.CategoryId == 0 ? article_.CategoryId : article.CategoryId;

                article_.CountryId = article.CountryId == 0 ? article_.CountryId : article.CountryId;

                article_.LanguageId = article.LanguageId == 0 ? article_.LanguageId : article.LanguageId;

                article_.UserId = 1;

                article_.CreateDate = article.CreateDate == null ? article_.CreateDate : article.CreateDate;

                article_.StateId = 1;               

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(article.ArticleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return Ok();
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

            return CreatedAtAction(nameof(GetArticle), new { q = _article.Title, id = _article.ArticleId }, _article);

        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            //var article = await _context.Articles.FindAsync(id);
            //if (article == null)
            //{
            //    return NotFound();
            //}

            //_context.Articles.Remove(article);
            //await _context.SaveChangesAsync();

            //return NoContent();

            try
            {
                var article_ = await _context.Articles.Where(x => x.ArticleId == id).FirstOrDefaultAsync();

                article_.StateId = 1;

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

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
