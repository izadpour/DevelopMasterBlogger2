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

        public void Add(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            Save();
        }

        public ArticleCategory GetBy(long id)
        {
            var result = _context.ArticleCategories.Find(id);
            return result;
        }

        public List<ArticleCategory> GetAll()
        {
            var result = _context.ArticleCategories.OrderByDescending(x => x.Id).ToList();
            return result;
        }

       

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}