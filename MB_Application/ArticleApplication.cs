using MB_Application_Contracts.Article;
using MB_Application_Contracts.ArticleCategory;
using MB_Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            var article = new 
                Article(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
            articleRepository.CreateAndSave(article);
        }

        public void Edit(EditArticle command)
        {
            var article = articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
            articleRepository.Save();
        }

        public EditArticle Get(long id)
        {
            var article = articleRepository.Get(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return articleRepository.GetList();
        }


        public void Activate(long id)
        {
            articleRepository.Get(id).Activate();
            articleRepository.Save();
        }

        public void Remove(long id)
        {
            //articleRepository.Get(id).Remove();
            var article = articleRepository.Get(id);
            article.Remove();
            articleRepository.Save();
        }
    }
}
