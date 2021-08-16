using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Create(ArticleCategory entity);
        ArticleCategory GetBy(long Id);

        List<ArticleCategory> GetAll();
    }
}