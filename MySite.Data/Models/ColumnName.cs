using System;
using System.Collections.Generic;
using System.Text;

namespace MySite.Data.Models
{
    public class ColumnName
    {
        public struct ArticleColumn
        {
            public static readonly string Id = "ARTICLE_ID";
            public static readonly string CategoryId = "ARTICLE_CATEGORY_ID";
            public static readonly string Title = "ARTICLE_TITLE";
            public static readonly string Content = "ARTICLE_CONTENT";
            public static readonly string Attachment = "ARTICLE_ATTACHMENT";
            public static readonly string Comment = "ARTICLE_COMMENT";
            public static readonly string Rate = "ARTICLE_RATE";
        }

        public struct AttachmentColumn
        {
            public static readonly string Id = "ATTACHMENT_ID";
            public static readonly string Name = "ATTACHMENT_NAME";
            public static readonly string File = "ATTACHMENT_FILE";
            public static readonly string Size = "ATTACHMENT_SIZE";
        }

        public struct CategoryColumn
        {
            public static readonly string Id = "CATEGORY_ID";
            public static readonly string Name = "CATEGORY_NAME";
            public static readonly string Color = "CATEGORY_COLOR";
        }

        public struct CommentColumn
        {
            public static readonly string Id = "COMMENT_ID";
            public static readonly string Content = "COMMENT_CONTENT";
        }
        
        public struct RateColumn
        {
            public static readonly string Id = "RATE_ID";
            public static readonly string Rate = "RATE";
        }

        public struct LogColumn
        {
            public static readonly string Id = "LOG_ID";
            public static readonly string Module = "LOG_MODULE";
            public static readonly string Function = "LOG_FUNCTION";
            public static readonly string Exception = "LOG_EXCEPTION";
            public static readonly string Message = "LOG_MESSAGE";
            public static readonly string StackTrace = "LOG_STACK_TRACE";
            public static readonly string Created = "LOG_CREATED";
        }

        public struct UserColumn
        {
            public static readonly string Id = "USER_ID";
            public static readonly string Name = "USER_NAME";
            public static readonly string Password = "PASSWORD";
            public static readonly string DisplayName = "DISPLAY_NAME";
            public static readonly string Picture = "PICTURE";
        }

        public struct SharedColumn
        {
            public static readonly string IsDelete = "IS_DELETE";
            public static readonly string CreatedBy = "CREATED_BY";
            public static readonly string Created = "CREATED";
        }
    }
}
