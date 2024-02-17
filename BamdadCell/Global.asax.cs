using GSD.Globalization;
using System;
using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace BamdadCell
{
    public class MvcApplication : System.Web.HttpApplication
    {


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        /// <summary>
        /// هنگام درخواست برنامه از 
        ///  فراخوانی میشود و در ترد ها ست میشود PersianCalture => Extentions/PersianCulture 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            PersianCulture persianCulture = new PersianCulture();
            persianCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
            persianCulture.DateTimeFormat.LongDatePattern = "dddd d MMMM yyyy";
            persianCulture.DateTimeFormat.AMDesignator = "";
            persianCulture.DateTimeFormat.PMDesignator = "";
            Thread.CurrentThread.CurrentCulture = persianCulture;
            Thread.CurrentThread.CurrentUICulture = persianCulture;
        }

    }
}
