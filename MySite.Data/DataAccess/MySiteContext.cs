using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySite.Data.Models;

namespace MySite.Data.DataAccess
{
    public class MySiteContext : DbContext
    {
        public MySiteContext(DbContextOptions options) : base(options) { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleAttachment> ArticleAttachments { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<ArticleRate> ArticleRates { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<User> Users { get; set; }

        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set Default Value ARTICLE Table
            modelBuilder.Entity<Article>(entityArticle =>
            {
                entityArticle.Property(p => p.ArticleId).HasDefaultValueSql("newsequentialid()");
                entityArticle.Property(p => p.ArticleRate).HasDefaultValueSql("(0.0)");
                entityArticle.Property(p => p.IsDelete).HasDefaultValueSql("(0)");
                entityArticle.Property(p => p.Created).HasDefaultValueSql("getdate()");
            //modelBuilder.Entity<Article>().Property(p => p.ArticleId).HasDefaultValueSql("newsequentialid()");
            });

            //Set Default Value ARTICLE_ATTACHMENT Table
            modelBuilder.Entity<ArticleAttachment>(entityArticleAttachment =>
            {
                entityArticleAttachment.Property(p => p.AttachmentId).HasDefaultValueSql("newsequentialid()");
                entityArticleAttachment.Property(p => p.IsDelete).HasDefaultValueSql("(0)");
                entityArticleAttachment.Property(p => p.Created).HasDefaultValueSql("getdate()");
            });

            //Set Default Value ARTICLE_CATEGORY Table
            modelBuilder.Entity<ArticleCategory>(entityArticleCatefory =>
            {
                entityArticleCatefory.Property(p => p.CategoryId).HasDefaultValueSql("newsequentialid()");
                entityArticleCatefory.Property(p => p.IsDelete).HasDefaultValueSql("(0)");
                entityArticleCatefory.Property(p => p.Created).HasDefaultValueSql("getdate()");
            });

            //Set Default Value ARTICLE_COMMENT Table
            modelBuilder.Entity<ArticleComment>(entityArticleComment =>
            {
                entityArticleComment.Property(p => p.CommentId).HasDefaultValueSql("newsequentialid()");
                entityArticleComment.Property(p => p.IsDelete).HasDefaultValueSql("(0)");
                entityArticleComment.Property(p => p.Created).HasDefaultValueSql("getdate()");
            });

            //Set Default Value ARTICLE_RATE Table
            modelBuilder.Entity<ArticleRate>(entityArticleRate =>
            {
                entityArticleRate.Property(p => p.RateId).HasDefaultValueSql("newsequentialid()");
                entityArticleRate.Property(p => p.IsDelete).HasDefaultValueSql("(0)");
                entityArticleRate.Property(p => p.Created).HasDefaultValueSql("getdate()");
            });

            //Set Default Value LOG Table
            modelBuilder.Entity<Log>(entityLog =>
            {
                entityLog.Property(p => p.LogId).HasDefaultValueSql("newsequentialid()");
                entityLog.Property(p => p.LogCreated).HasDefaultValueSql("getdate()");
            });

            //Set Default Value USER Table
            modelBuilder.Entity<User>(entityUser =>
            {
                entityUser.Property(p => p.UserId).HasDefaultValueSql("newsequentialid()");
                entityUser.Property(p => p.IsDelete).HasDefaultValueSql("(0)");
                entityUser.Property(p => p.Created).HasDefaultValueSql("getdate()");
            });
        }
    }
}
