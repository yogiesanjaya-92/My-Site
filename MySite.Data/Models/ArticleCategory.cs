using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySite.Data.Models
{
    [Table("ARTICLE_CATEGORY")]
    public class ArticleCategory
    {
        [Key]
        [Column("CATEGORY_ID")]
        public Guid? CategoryId { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("CATEGORY_NAME", TypeName = "varchar(255)")]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("CATEGORY_COLOR", TypeName = "varchar(10)")]
        public string CategoryColor { get; set; }
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