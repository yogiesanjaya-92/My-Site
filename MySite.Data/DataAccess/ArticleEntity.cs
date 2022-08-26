using LinqKit;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MySite.Data.Models;
using MySite.Util.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MySite.Data.DataAccess
{
    public class ArticleEntity
    {
        public static DataTable GetNewestArticle(MySiteContext _dbContext)
        {
            DataTable dtResult = new DataTable(typeof(Article).Name);

            if (_dbContext.Articles.Count() > 0)
            {
                //Default Type String
                dtResult.Columns.Add(ColumnName.ArticleColumn.Id, typeof(Guid));
                dtResult.Columns.Add(ColumnName.ArticleColumn.Title);
                dtResult.Columns.Add(ColumnName.ArticleColumn.Content);

                //Using Predicate Builder
                var predicate = PredicateBuilder.New<Article>(true);
                predicate = predicate.And(ar => ar.ArticleId != Guid.Empty);

                //Result Order, Take and Select Column
                var query = _dbContext.Articles.Where(predicate).OrderBy(x => x.Created)
                    .Skip(0).Take(5)
                    .Select(x => dtResult.Rows.Add(
                        x.ArticleId,
                        x.ArticleTitle,
                        x.ArticleContent));
                dtResult = query.CopyToDataTable();
            }

            return dtResult;
        }
    }
}
