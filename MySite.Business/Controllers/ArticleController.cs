using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySite.Business.Models;
using MySite.Data.DataAccess;
using MySite.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MySite.Business.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly MySiteContext _mySiteContext;

        public ArticleController(ILogger<ArticleController> logger, MySiteContext dbContext)
        {
            _logger = logger;
            _mySiteContext = dbContext;
        }

        public ActionResult getArticle()
        {
            var lstArticle = new List<ArticleViewModel>();

            if (_mySiteContext.Articles.Any())
            {
                //Call SP     
                string ConnectionString = _mySiteContext.Database.GetDbConnection().ConnectionString;

                using (SqlConnection oSqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedureName.Article.GET_BY_ID, oSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ARTICLE_ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse("da20c93c-cd73-ea11-a8e6-000c292672ea");
                        oSqlConnection.Open();
                        using (SqlDataReader dtReader = cmd.ExecuteReader())
                        {
                            if (dtReader.Read())
                            {
                                lstArticle.Add(new ArticleViewModel()
                                {
                                    Category = dtReader[ColumnName.CategoryColumn.Name].ToString(),
                                    Title = dtReader[ColumnName.ArticleColumn.Title].ToString(),
                                    Content = dtReader[ColumnName.ArticleColumn.Content].ToString()
                                });
                            }
                        }
                    }
                }


                //Using Predicate Builder
                var predicate = PredicateBuilder.New<Article>(true);
                predicate = predicate.And(ar => ar.ArticleId != Guid.Empty);

                //Result Order, Take and Select Column
                var results = _mySiteContext.Articles.Where(predicate).OrderBy(x => x.Created)
                    .Skip(0).Take(5)
                    .Select(x => new Article()
                    {
                        ArticleId = x.ArticleId,
                        ArticleTitle = x.ArticleTitle,
                        ArticleContent = x.ArticleContent
                    }).ToList();

                if (results.Any())
                {
                    foreach (var article in results)
                    {
                        lstArticle.Add(new ArticleViewModel()
                        {
                            Title = article.ArticleTitle,
                            Content = article.ArticleContent
                        });
                    }
                }
            }

            return View("", lstArticle);
        }
    }
}
