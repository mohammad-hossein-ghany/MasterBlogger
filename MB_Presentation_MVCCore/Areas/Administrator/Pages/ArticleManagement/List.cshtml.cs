using System.Collections.Generic;
using MB_Application_Contracts.Article;
//using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            this.articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = articleApplication.GetList();
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            articleApplication.Remove(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostActivate(long id)
        {
            articleApplication.Activate(id);
            return RedirectToPage("./List");
        }

    }
}