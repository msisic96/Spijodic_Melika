using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Spijodic_Melika.Model;

namespace Spijodic_Melika.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {

        private readonly ArticleDbContext _context;

        public ArticleController(ArticleDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns>
        /// List of articles
        /// </returns>
        [HttpGet("GetAllArticles")]
        public List<Article> GetAllArticles()
        {
            try
            {
                return _context.Articles.ToList();
            }
            catch
            {
                var resp = new System.Net.Http.HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new System.Net.Http.StringContent(string.Format("No articles found")),
                    ReasonPhrase = "Articles Not Found"
                };

                throw new System.Web.Http.HttpResponseException(resp);
            }
        }

        /// <summary>
        /// Get the number of sold articles per day
        /// </summary>
        /// <returns>
        /// List of dates and number of sold articles per date
        /// </returns>
        [HttpGet("GetNumberOfSoldArticlesPerDay")]
        public List<Tuple<DateTime, int>> GetNumberOfSoldArticlesPerDay()
        {
            try
            {
                List<Tuple<DateTime, int>> result = _context.Articles.GroupBy(a => a.Date)
                .Select(aa => new Tuple<DateTime, int>(aa.First().Date, aa.Count())).ToList();
                return result;
            }
            catch
            {
                var resp = new System.Net.Http.HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new System.Net.Http.StringContent(string.Format("No articles found")),
                    ReasonPhrase = "Articles Not Found"
                };

                throw new System.Web.Http.HttpResponseException(resp);
            }
            
        }

        /// <summary>
        /// Get the total revenue per day
        /// </summary>
        /// <returns>
        /// List of dates and total revenue per date
        /// </returns>
        [HttpGet("GetTotalRevenuePerDay")]
        public List<Tuple<DateTime, double>> GetTotalRevenuePerDay()
        {
            try
            {
                List<Tuple<DateTime, double>> result = _context.Articles.GroupBy(a => a.Date)
                   .Select(aa => new Tuple<DateTime, double>(aa.First().Date, aa.Sum(aaa => aaa.Price))).ToList();

                return result;
            }
            catch
            {
                var resp = new System.Net.Http.HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new System.Net.Http.StringContent(string.Format("No articles found")),
                    ReasonPhrase = "Articles Not Found"
                };

                throw new System.Web.Http.HttpResponseException(resp);
            }
            
        }


        /// <summary>
        /// Get the article(s) by id
        /// </summary>
        /// <param name="id">
        /// The article id value
        /// </param>
        /// <returns>
        /// Article with given id
        /// </returns>
        [HttpGet("GetArticleById/{id}")]
        public Article GetArticleById(int id)
        {
            Article item = _context.Articles.SingleOrDefault(a => a.Id == id);
            if (item == null)
            {
                var resp = new System.Net.Http.HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new System.Net.Http.StringContent(string.Format("No article with id = {0}", id)),
                    ReasonPhrase = "Article Not Found"
                };

                throw new System.Web.Http.HttpResponseException(resp);
            }
            return item;
        }

        /// <summary>
        /// Get the revenue grouped by articles
        /// </summary>
        /// <returns>
        /// List of article numbers and total revenue for the article
        /// </returns>
        [HttpGet("GetRevenueByArticles")]
        public List<Tuple<string, double>> GetRevenueByArticles()
        {
            try
            {
                List<Tuple<string, double>> result = _context.Articles.GroupBy(a => a.Number)
                   .Select(aa => new Tuple<string, double>(aa.First().Number, aa.Sum(aaa => aaa.Price))).ToList();

                return result;
            }
            catch
            {
                var resp = new System.Net.Http.HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new System.Net.Http.StringContent(string.Format("No articles found")),
                    ReasonPhrase = "Articles Not Found"
                };

                throw new System.Web.Http.HttpResponseException(resp);
            }
            
        }

        /// <summary>
        /// Add a new article
        /// </summary>
        /// <param name="article_number">
        /// Article number in alphanumeric format
        /// </param>
        /// <param name="sales_price">
        /// Articles' sales price in euros
        /// </param>
        /// <returns>
        /// ActionResult
        /// </returns>
        [HttpPost("AddArticle")]
        public IActionResult AddArticle(string article_number, double sales_price)
        {
            int id = 1;
            if (_context.Articles.LastOrDefault() != null)
            {
                id = _context.Articles.LastOrDefault().Id + 1;
             
            }

            if (sales_price.Equals(null) || article_number == null)
                return BadRequest("Please enter all required fields!");

            if(!article_number.All(c => char.IsLetterOrDigit(c)))
                return BadRequest("Article number should contain only numbers and letters!");

            if (sales_price < 0.0)
                return BadRequest("Sales price should be a positive value!");

            if (article_number.Length > 32)
                return BadRequest("Article number should not be more than 32 characters!");

            Article article = new Article
            {
                Id = id,
                Number = article_number,
                Price = sales_price,
                Date = DateTime.Now
            };

            _context.Articles.Add(article);
            _context.SaveChanges();
            return Ok("Article with number = " + article_number + " created successfully");
        }

        /// <summary>
        /// Delete the article
        /// </summary>
        /// <param name="id">
        /// The article id value
        /// </param>
        /// <returns>
        /// ActionResult
        /// </returns>
        [HttpDelete("DeleteArticle/{id}")]
        public IActionResult DeleteArticle(int id)
        {
            Article item = _context.Articles.SingleOrDefault(a => a.Id == id);

            if (item == null)
                return BadRequest(string.Format("No article with article id = {0}", id));

            _context.Remove(item);
            _context.SaveChanges();

            return Ok("Article with id = " + id + " deleted successfully!");
        }
    }
}
