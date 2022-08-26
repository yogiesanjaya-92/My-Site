using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySite.Data.Models
{
    [Table("USER")]
    public class User
    {
        [Key]
        [Column("USER_ID")]
        public Guid? UserId { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("USER_NAME", TypeName = "varchar(255)")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("PASSWORD", TypeName = "varchar(255)")]
        public string Password { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("DISPLAY_NAME",TypeName = "varchar(255)")]
        public string DisplayName { get; set; }
        [Required]
        [MaxLength(2083)]
        [Column("PICTURE",TypeName = "varchar(2083)")]
        public string Picture { get; set; }
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
