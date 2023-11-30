using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu_HoDangTai_63135354
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
