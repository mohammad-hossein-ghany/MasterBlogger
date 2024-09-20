using System.Collections.Generic;
using MB_Application_Contracts.ArticleCategory;
//using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = articleCategoryApplication.List();
        }

        public RedirectToPageResult OnPostActivate(long id)
        {
            articleCategoryApplication.Active(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            articleCategoryApplication.Remove(id);
            return RedirectToPage("./List");
        }

    }
}
