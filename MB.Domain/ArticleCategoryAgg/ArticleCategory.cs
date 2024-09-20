using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime creationDate { get; private set; }


        public ArticleCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            creationDate = DateTime.Now;
        }



    }
}
