using MB_Domain.ArticleAgg;
using MB_Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public List<Article> Articles { get; private set; }

        public ArticleCategory()
        {
        }

        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle(title);
            validatorService.CheckExists(title);

            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Articles = new List<Article>();
        }

        public void Edit(string title)
        {
            GuardAgainstEmptyTitle(title);

            this.Title = title;
        }

        public void Activate()
        {
            IsDeleted = false;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException();
        }

    }
}
