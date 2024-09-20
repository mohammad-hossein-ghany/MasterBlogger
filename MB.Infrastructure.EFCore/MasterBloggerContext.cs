using MB.Domain.ArticleCategoryAgg;
using MB_Domain.ArticleAgg;
using MB_Domain.CommentAgg;
using MB_Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore
{
    public class MasterBloggerContext : DbContext
    {

        public DbSet<ArticleCategory> articleCategories { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<Comment> Comments { get; set; }



        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
