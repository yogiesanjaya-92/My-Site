using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySite.Data.Models
{
    [Table("ARTICLE")]
    public class Article
    {
        [Key]
        [Column("ARTICLE_ID")]
        public Guid? ArticleId { get; set; }
        [Required]
        [Column("ARTICLE_CATEGORY_ID")]
        public Guid ArticleCategoryId { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("ARTICLE_TITLE", TypeName = "varchar(255)")]
        public string ArticleTitle { get; set; }
        [Required]
        [Column("ARTICLE_CONTENT")]
        public string ArticleContent { get; set; }
        [Required]
        [Column("ARTICLE_ATTACHMENT")]
        public int ArticleAttachment { get; set; }
        [Required]
        [Column("ARTICLE_COMMENT")]
        public int ArticleComment { get; set; }
        [Required]
        [RegularExpression(@"^\d\.\d{0,2}$")]
        [Range(0, 9.99)]
        [Column("ARTICLE_RATE", TypeName = "decimal(3,2)")]
        public decimal? ArticleRate { get; set; }
        [Column("IS_DELETE")]
        public bool? IsDelete { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("CREATED_BY",TypeName = "varchar(255)")]
        public string CreatedBy { get; set; }
        [Column("CREATED")]
        public DateTime? Created { get; set; }
    }
}
