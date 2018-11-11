using System;
using System.Web;
using System.Web.Mvc;

namespace SimpleForumEngine.web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            HandleErrorAttribute atr = new HandleErrorAttribute();
            atr.ExceptionType = typeof(Exception);
            atr.View = "Error";
            filters.Add(atr);
        }
    }
}
