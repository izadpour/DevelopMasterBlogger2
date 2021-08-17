using MB.Application.Contracts.ArticleCategory;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
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

        public void Create(ArticleCategoryCreate command)
        {
            ArticleCategory articleCategory = new ArticleCategory(command.Title,_articleCategoryValidatorService);
           
           _articleCategoryRepository.Add(articleCategory);
        }

        public void Rename(ArticleCategoryRename command)
        {
           var articleCategory =  _articleCategoryRepository.GetBy(command.Id);
           articleCategory.Rename(command.Title);
           _articleCategoryRepository.Save();

        }

        public ArticleCategoryRename GetBy(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            return new ArticleCategoryRename
            {
                 Id = articleCategory.Id,
                 Title = articleCategory.Title
            };

        }

        public void Remove(long id)
        {
           var articleCategory =  _articleCategoryRepository.GetBy(id);
           articleCategory.Remove();
           _articleCategoryRepository.Save();
        }

        public void Active(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Active();
            _articleCategoryRepository.Save();
        }
    }
}