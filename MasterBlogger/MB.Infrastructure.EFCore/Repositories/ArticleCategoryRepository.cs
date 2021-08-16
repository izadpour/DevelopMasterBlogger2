using System.Collections.Generic;
using System.Linq;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Create(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            _context.SaveChanges();
        }

        public ArticleCategory GetBy(long Id)
        {
            var result = _context.ArticleCategories.Find(Id);
            return result;
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.ToList();
        }
    }
}