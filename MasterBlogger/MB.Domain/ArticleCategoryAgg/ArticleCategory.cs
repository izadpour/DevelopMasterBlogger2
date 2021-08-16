﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.ArticleCategoryAgg
{
   public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsDeleted { get; private set; }

        public ArticleCategory(string title)
        {
            Title = title;
            CreationDate=DateTime.Now;
            IsDeleted = false;
        }
    }
}
