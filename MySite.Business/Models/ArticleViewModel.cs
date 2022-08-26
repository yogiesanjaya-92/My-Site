using System;
using System.Collections.Generic;
using System.Text;

namespace MySite.Business.Models
{
    public class ArticleViewModel
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Attachment { get; set; }
        public int Comment { get; set; }
        public decimal Rate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
