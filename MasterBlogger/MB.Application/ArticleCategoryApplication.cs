using MB.Application.Contracts.ArticleCategory;
using System.Collections.Generic;
using System.Globalization;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public List<ArticleCategoryViewModel> List()
        {
            List<ArticleCategoryViewModel> result = new List<ArticleCategoryViewModel>();

            var articleCategories = _articleCategoryRepository.GetAll();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture),
                    IsDeleted = articleCategory.IsDeleted,
                    Title = articleCategory.Title
                });
            }

            return result;
        }
    }
}