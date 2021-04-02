using System.Web;
using System.Web.Mvc;

namespace Online_Bill_Management_Systm
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
