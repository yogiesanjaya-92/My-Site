using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySite.Data.Models
{
    [Table("ARTICLE_COMMENT")]
    public class ArticleComment
    {
        [Key]
        [Column("COMMENT_ID")]
        public Guid? CommentId { get; set; }
        [Required]
        [Column("ARTICLE_ID")]
        public Guid ArticleId { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("COMMENT_CONTENT")]
        public string CommentContent { get; set; }
        [Column("IS_DELETE")]
        public bool? IsDelete { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("CREATED_BY", TypeName = "varchar(255)")]
        public string CreatedBy { get; set; }
        [Column("CREATED")]
        public DateTime? Created { get; set; }
    }
}
