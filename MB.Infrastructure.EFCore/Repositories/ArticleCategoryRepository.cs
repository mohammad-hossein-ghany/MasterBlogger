using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            this.context = context;
        }

        public void Add(ArticleCategory entity)
        {
            context.articleCategories.Add(entity);
            context.SaveChanges();
        }

        public bool Exists(long id)
        {
            return context.articleCategories.Any(x => x.Id == id);

        }

        public bool Exists(string title)
        {
            return context.articleCategories.Any(x => x.Title == title);
        }

        public ArticleCategory Get(long id)
        {
            var articleCategory = context.articleCategories.FirstOrDefault(x => x.Id == id);
            return articleCategory;
        }

        public List<ArticleCategory> GetAll()
        {
            return context.articleCategories.OrderBy(x => x.Id).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
