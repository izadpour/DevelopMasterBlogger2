using System.Collections.Generic;

namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(ArticleCategoryCreate command);

        void Rename(ArticleCategoryRename command);
        ArticleCategoryRename GetBy(long id);
        void Remove(long id);
        void Active(long id);
    }
}