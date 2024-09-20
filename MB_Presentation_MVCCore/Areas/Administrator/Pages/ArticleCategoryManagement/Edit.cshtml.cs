//using MB.Application.Contracts.ArticleCategory;
using MB_Application;
using MB_Application_Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty] public RenameArticleCategory ArticleCategory { get; set; }
        private readonly IArticleCategoryApplication articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            ArticleCategory = articleCategoryApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
            articleCategoryApplication.Edit(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}