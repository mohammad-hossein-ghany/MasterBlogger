using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application_Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(CreateArticleCategory entity);
        void Edit(RenameArticleCategory entity);
        RenameArticleCategory Get(long id);
        void Active(long id);
        void Remove(long id);

    }
}
