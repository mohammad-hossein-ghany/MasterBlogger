using MB_Application_Contracts.Comment;
using MB_Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggerContext context;

        public CommentRepository(MasterBloggerContext context)
        {
            this.context = context;
        }

        public void CreateAndSave(Comment Entity)
        {
            context.Comments.Add(Entity);
            context.SaveChanges();
        }

        public Comment Get(long id)
        {
            return context.Comments.FirstOrDefault(x => x.Id == id);
        }

        public List<CommentViewModel> GetList()
        {
            return context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Status = x.Status,
                CreationDate = x.CreationDate.ToString(),
                Article = x.Article.Title
            }).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
