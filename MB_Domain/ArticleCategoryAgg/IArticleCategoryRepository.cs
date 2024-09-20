using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Add(ArticleCategory entity);
        List<ArticleCategory> GetAll();
        bool Exists(long id);
        bool Exists(string title);
        ArticleCategory Get(long id);
        void Save();
    }
}
