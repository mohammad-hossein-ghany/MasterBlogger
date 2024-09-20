using MB_Application_Contracts.Article;
using MB_Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext context;

        public ArticleRepository(MasterBloggerContext context)
        {
            this.context = context;
        }

        public void CreateAndSave(Article entity)
        {
            context.articles.Add(entity);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public List<ArticleViewModel> GetList()
        {
            return context.articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
               Id = x.Id,
               Title = x.Title,
               ArticleCategory = x.ArticleCategory.Title,
               IsDeleted = x.IsDeleted,
               CreationDate = x.CreationDate.ToString()
            }).ToList();
        }

        public Article Get(long id)
        {
            return context.articles.FirstOrDefault(x => x.Id == id);
        }
    }
}
