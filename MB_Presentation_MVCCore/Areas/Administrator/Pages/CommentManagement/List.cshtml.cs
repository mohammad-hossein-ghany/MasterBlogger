using System.Collections.Generic;
using MB_Application_Contracts.Comment;
//using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }
        private readonly ICommentApplication commentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            this.commentApplication = commentApplication;
        }


        public void OnGet()
        {
            Comments = commentApplication.GetList();
        }

        public RedirectToPageResult OnPostConfirm(long id)
        {
            commentApplication.Confirm(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostCancel(long id)
        {
            commentApplication.Cancel(id);
            return RedirectToPage("./List");
        }


    }
}