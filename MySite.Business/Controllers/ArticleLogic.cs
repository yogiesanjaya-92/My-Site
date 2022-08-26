using Microsoft.AspNetCore.Mvc;
using MySite.Business.Model;
using MySite.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MySite.Business.Controllers
{
    public class ArticleLogic : ControllerBase
    {
        private readonly MySiteContext _mySiteContext;

        public ArticleLogic(MySiteContext dbContext)
        {
            _mySiteContext = dbContext;
        }

        [HttpPost]
        public JsonResult getArtic()
        {
            ArticleViewModel article = new ArticleViewModel();
            var dtTable = ArticleEntity.GetNewestArticle(_mySiteContext);
            if (dtTable.Rows.Count > 0)
            {
                article.Title = dtTable.Rows[0].Field<string>(Data.Models.ColumnName.ArticleColumn.Title);
            }
            return new JsonResult(article);
        }

        public ActionResult<ArticleViewModel> getArticle()
        {
            ArticleViewModel article = new ArticleViewModel();
            var dtTable = ArticleEntity.GetNewestArticle(_mySiteContext);
            if (dtTable.Rows.Count > 0)
            {
                article.Title = dtTable.Rows[0].Field<string>(Data.Models.ColumnName.ArticleColumn.Title);
            }
            return article;
        }
    }
}
