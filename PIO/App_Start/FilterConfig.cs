using PIO.App_Start;
using System.Web;
using System.Web.Mvc;

namespace PIO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PassCategoryTree());
        }
    }
}
