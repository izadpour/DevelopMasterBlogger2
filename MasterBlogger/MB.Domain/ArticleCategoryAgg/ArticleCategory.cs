using System;
using System.Collections.Generic;
using System.Text;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Service;

namespace MB.Domain.ArticleCategoryAgg
{
   public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Article> Articles { get; private set; }
        protected ArticleCategory()
        {
        }
        public ArticleCategory(string title,IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            GuardAgainstEmptyTitle(title);
            articleCategoryValidatorService.CheckThatThisRecordAlreadyExists(title);
            Title = title;
            CreationDate=DateTime.Now;
            IsDeleted = false;
            Articles = new List<Article>();
        }

        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }

        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }
        public void Active()
        {
            IsDeleted = false;
        }

    }

}
