using MB_Application_Contracts.Comment;
using MB_Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            commentRepository.CreateAndSave(comment);
        }

        public List<CommentViewModel> GetList()
        {
            return commentRepository.GetList();
        }

        public void Cancel(long id)
        {
            commentRepository.Get(id).Cancel();
            commentRepository.Save();
        }

        public void Confirm(long id)
        {
            commentRepository.Get(id).Confirm();
            commentRepository.Save();
        }

    }
}
