using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application_Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
        public void Edit(EditArticle command);
        public EditArticle Get(long id);
        public void Activate(long id);
        public void Remove(long id);
    }
}
