//using MB.Application.Contracts.Comment;
//using MB.Infrastructure.Query;
using MB_Application_Contracts.Comment;
using MB_Infrastructure_Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {

        public ArticleQueryView Article { get; set; }
        private readonly IArticleQuery articleQuery;

        private readonly ICommentApplication commentApplication;


        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            this.articleQuery = articleQuery;
            this.commentApplication = commentApplication;
        }


        public void OnGet(long id)
        {
            Article = articleQuery.GetArticle(id);
        }

        public RedirectToPageResult OnPost(AddComment command)
        {
            commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails");
        }
    }
}