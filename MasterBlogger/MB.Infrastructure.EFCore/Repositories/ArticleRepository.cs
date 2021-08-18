using System.Collections.Generic;
using System.Linq;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<Article> GetAll()
        {
            return _context.Articles.Include(x => x.ArticleCategory).ToList();
        }
    }
}