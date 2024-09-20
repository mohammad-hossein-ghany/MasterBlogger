using System.Collections.Generic;
using System.Linq;
using MB_Application_Contracts.Article;
using MB_Application_Contracts.ArticleCategory;
//using System.Security.Permissions;
//using MB.Application.Contracts.Article;
//using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        public List<SelectListItem> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication articleCategoryApplication;
        private readonly IArticleApplication articleApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
            this.articleApplication = articleApplication;
        }

        public void OnGet()
        {
            ArticleCategories = articleCategoryApplication.List().Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }


        public RedirectToPageResult OnPost(CreateArticle command)
        {
            articleApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}