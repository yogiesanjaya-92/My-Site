using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MySite.Data.DataAccess
{
    public class LogEntity
    {
        public static void WriteLog(MySiteContext _dbContext, Exception exception, MethodBase methodBase)
        {
            Models.Log log = new Models.Log()
            {
                LogFunction = methodBase.Name,
                LogModule = methodBase.ReflectedType.Name,
                LogException = exception.GetType().Name,
                LogMessage = exception.Message,
                LogStackTrace = exception.StackTrace,
            };
            _dbContext.Logs.Add(log);
            _dbContext.SaveChanges();
        }
    }
}
