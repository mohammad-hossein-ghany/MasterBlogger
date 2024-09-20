using MB.Domain.ArticleCategoryAgg;
using MB_Application_Contracts.ArticleCategory;
using MB_Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IArticleCategoryValidatorService articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository , IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public void Create(CreateArticleCategory entity)
        {
            var articleCategory = new ArticleCategory(entity.Title ,articleCategoryValidatorService);
            articleCategoryRepository.Add(articleCategory);
        }

        public void Edit(RenameArticleCategory entity)
        {
            if (articleCategoryRepository.Exists(entity.Id))
            {
                var articleCategory = articleCategoryRepository.Get(entity.Id);
                articleCategory.Edit(entity.Title);
                articleCategoryRepository.Save();
            }
        }

        public RenameArticleCategory Get(long id)
        {
            var aticleCategory = articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = aticleCategory.Id,
                Title = aticleCategory.Title
            };
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString()
                });
            }
            return result;
        }

        public void Active(long id)
        {
            articleCategoryRepository.Get(id).Activate();
            articleCategoryRepository.Save();
        }

        public void Remove(long id)
        {
            articleCategoryRepository.Get(id).Remove();
            articleCategoryRepository.Save();
        }
    }
}
