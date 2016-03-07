using System.Web;
using System.Web.Mvc;

namespace OPP_Minneapolis
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
