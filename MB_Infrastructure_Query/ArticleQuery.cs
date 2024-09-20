using MB_Domain.CommentAgg;
using MB_Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB_Infrastructure_Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext context;

        public ArticleQuery(MasterBloggerContext context)
        {
            this.context = context;
        }


        public List<ArticleQueryView> GetArticles()
        {
            return context.articles
                .Include(x => x.Comments)
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(),
                    Image = x.Image,
                    CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed)
                }).ToList();
        }


        public ArticleQueryView GetArticle(long id)
        {
            return context.articles
                .Include(x => x.Comments)
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(),
                    Image = x.Image,
                    Content = x.Content,
                    CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),
                    Comments = MapComments(x.Comments.Where(x=>x.Status == Statuses.Confirmed))
                }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(x => new CommentQueryView
            {
                Name = x.Name,
                Message = x.Message,
                CreationDate = x.CreationDate.ToString()
            }).ToList();

        }

    }
}
