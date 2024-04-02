using System.Web;
using System.Web.Mvc;

namespace ProyectoAula3EmanuelGallego_SaraPineda
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
