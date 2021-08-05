using System.Web;
using System.Web.Mvc;

namespace RealEstateAspNetMVC5_Staj2021
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
