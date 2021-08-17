using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Add(ArticleCategory entity);
        ArticleCategory GetBy(long id);

        List<ArticleCategory> GetAll();

        bool Exists(string title);

        void Save();
    }
}