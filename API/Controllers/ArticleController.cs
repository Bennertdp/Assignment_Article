using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ArticleController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetAllArticles")]
        public async Task<ActionResult<List<ArticleViewModel>>> GetAllArticles()
        {
            var articles = await _context.Articles.Include(x => x.ArticleDescriptions).ToListAsync();
            var articleViewModels = _mapper.Map<List<ArticleViewModel>>(articles);
            return articleViewModels;
        }

        [HttpPost("AddArticle")]
        public async Task<ActionResult> AddArticle(ArticleViewModel article)
        {
            var articleEntity = _mapper.Map<Articles>(article);
            await _context.Articles.AddAsync(articleEntity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("EditArticle")]
        public async Task<ActionResult> EditArticle(ArticleViewModel article)
        {
            var dbArticle = await _context.Articles.FindAsync(article.ArticleId);
            if (dbArticle == null)
            {
                return NotFound();
            }

            _mapper.Map(article, dbArticle);

            var descriptionsToRemove = dbArticle.ArticleDescriptions.Where(ad => !article.ArticleDescriptions.Any(advm => advm.Language == ad.Language)).ToList();
            foreach (var descriptionToRemove in descriptionsToRemove)
            {
                _context.ArticleDescriptions.Remove(descriptionToRemove);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteArticle/{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var dbArticle = await _context.Articles.FindAsync(id);
            if (dbArticle == null)
            {
                return NotFound();
            }
            _context.Articles.Remove(dbArticle);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
