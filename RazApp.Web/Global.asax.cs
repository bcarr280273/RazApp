using Microsoft.AspNet.SignalR;
using RazApp.Core.Helpers;
using RazApp.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;


namespace RazApp.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            

            #region Area config
            AreaRegistration.RegisterAllAreas();
            #endregion

            #region CORS config
            //Cross Domain Web API service call
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());
            GlobalConfiguration.Configuration.Formatters.Insert(0, new JsonpFormatter());
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            #endregion

            #region Route config
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            #endregion

            #region Bundling config
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            #endregion

            #region Filter config
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            #endregion

            #region Open Authentication config
            AuthConfig.RegisterAuth();
            #endregion

            #region SignalR config
            HubConfiguration hubConfig = new HubConfiguration();
            hubConfig.EnableCrossDomain = true;
            RouteTable.Routes.MapHubs(hubConfig);
            #endregion
                       
          
            #region Bootstrapper
            Bootstrapper.Run();
            #endregion

           
           
        }
    }
}