using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySite.Data.Models
{
    [Table("LOG")]
    public class Log
    {
        [Key]
        [Column("LOG_ID")]
        public Guid? LogId { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("LOG_MODULE",TypeName = "varchar(255)")]
        public string LogModule { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("LOG_FUNCTION", TypeName = "varchar(255)")]
        public string LogFunction { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("LOG_EXCEPTION", TypeName = "varchar(255)")]
        public string LogException { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("LOG_MESSAGE", TypeName = "varchar(255)")]
        public string LogMessage { get; set; }
        [Required]
        [Column("LOG_STACK_TRACE", TypeName = "varchar(MAX)")]
        public string LogStackTrace { get; set; }
        [Column("LOG_CREATED")]
        public DateTime? LogCreated { get; set; }
    }
}
