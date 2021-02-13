using System.Web;
using System.Web.Mvc;

namespace NEXT.Project.SuperForum.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
