using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySite.Business.Controllers;
using MySite.Data.DataAccess;

namespace MySite.Web.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;
        private readonly MySiteContext _mySiteContext;

        public HomeModel(ILogger<HomeModel> logger, MySiteContext dbContext)
        {
            _logger = logger;
            _mySiteContext = dbContext;
        }

        public void OnGet()
        {
            try
            {
                Convert.ToInt32("1");
            }
            catch (Exception ex)
            {
                StackTrace stackTrace = new StackTrace(ex);
                Assembly assembly = Assembly.GetExecutingAssembly();
                MethodBase method = stackTrace.GetFrames().Select(f => f.GetMethod()).First(m => m.Module.Assembly == assembly);

                LogEntity.WriteLog(_mySiteContext, ex, method);
            }
        }
    }
}
