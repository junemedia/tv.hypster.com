using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace hypster_tv
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );




            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "VDefault",
                url: "video/{video_id}",
                defaults: new { controller = "video", action = "getVideo", video_id = "" }
            );
            //--------------------------------------------------------------------------------------------


            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "VvDefault",
                url: "v/{video_id}",
                defaults: new { controller = "v", action = "getVideo", video_id = "" }
            );
            //--------------------------------------------------------------------------------------------


            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "Vv1Default",
                url: "v1/{video_id}",
                defaults: new { controller = "v1", action = "getVideo", video_id = "" }
            );
            //--------------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "Vv2Default",
                url: "v2/{video_id}",
                defaults: new { controller = "v2", action = "getVideo", video_id = "" }
            );
            //--------------------------------------------------------------------------------------------


            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "Vv3Default",
                url: "v3/{video_id}",
                defaults: new { controller = "v3", action = "getVideo", video_id = "" }
            );
            //--------------------------------------------------------------------------------------------


            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "Vv4Default",
                url: "v4/{video_id}",
                defaults: new { controller = "v4", action = "getVideo", video_id = "" }
            );
            //--------------------------------------------------------------------------------------------







            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "PDefault",
                url: "page/{page_id}",
                defaults: new { controller = "home", action = "getPage", page_id = "" }
            );
            //--------------------------------------------------------------------------------------------




            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "Upload",
                url: "upload",
                defaults: new { controller = "upload", action = "Index" }
            );
            //--------------------------------------------------------------------------------------------




            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
           //--------------------------------------------------------------------------------------------


            



           

            
        }
    }
}