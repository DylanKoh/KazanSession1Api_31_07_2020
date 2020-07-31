using System.Web;
using System.Web.Mvc;

namespace KazanSession1Api_31_07_2020
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
