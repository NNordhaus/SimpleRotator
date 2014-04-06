using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleRotator
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("Content/PIE.htc");

            //              Route name      URL with params                     Param Defaults
            routes.MapRoute("GetAd",        "GetAd/{zone}",                     new { controller = "Ad", action = "GetAd" });
            routes.MapRoute("Default",      "{controller}/{action}/{id}",       new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            
        }

        protected void Application_Start()
        {
            // Only keep the ViewEngines we are going to need: http://blogs.msdn.com/b/marcinon/archive/2011/08/16/optimizing-mvc-view-lookup-performance.aspx
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            this.Error += new EventHandler(Application_Error);

            // Load all zones and ads
            //Managers.AdRepo.
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            
        }
    }
}