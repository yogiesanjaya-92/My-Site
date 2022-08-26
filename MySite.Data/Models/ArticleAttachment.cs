using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySite.Data.Models
{
    [Table("ARTICLE_ATTACHMENT")]
    public class ArticleAttachment
    {
        [Key]
        [Column("ATTACHMENT_ID")]
        public Guid? AttachmentId { get; set; }
        [Required]
        [Column("ARTICLE_ID")]
        public Guid ArticleId { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("ATTACHMENT_NAME", TypeName ="varchar(255)")]
        public string AttachmentName { get; set; }
        [Required]
        [Column("ATTACHMENT_FILE",TypeName = "text")]
        public string AttachmentFile { get; set; }
        [Required]
        [MaxLength(5)]
        [Column("ATTACHMENT_SIZE",TypeName = "varchar(5)")]
        public string AttachmentSize { get; set; }
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
