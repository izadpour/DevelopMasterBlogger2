using MB.Application.Contracts.Article;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> List()
        {
            
            List<ArticleViewModel> result = new List<ArticleViewModel>();
            var articles = _articleRepository.GetAll();

            foreach (var article in articles)
            {
                result.Add(new ArticleViewModel
                {
                    Id = article.Id,
                    Title = article.Title,
                    ArticleCategory = article.ArticleCategory.Title,
                    IsDeleted = article.IsDeleted,
                    CreationDate = article.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }

            return result;
        }
    }
}