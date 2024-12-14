using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _14_Filters.CustomFilter
{
    public class TrackRequestFilterAttribute:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName=filterContext.RouteData.Values["action"];

            string message = $"{controllerName} => {actionName} => OnActionExecuting @ {DateTime.Now}";

            Log(message);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];

            string message = $"{controllerName} => {actionName} => OnActionExecuted @ {DateTime.Now}";

            Log(message);
        }


        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];

            string message = $"{controllerName} => {actionName} => OnResultExecuting @ {DateTime.Now}";

            Log(message);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];

            string message = $"{controllerName} => {actionName} => OnResultExecuted @ {DateTime.Now}";

            Log(message);
        }
        public void Log(string message) {

            string logFolder = HttpContext.Current.Server.MapPath("~");

            string filePath = Path.Combine(logFolder, @"Data\Logs.txt");
            File.AppendAllText(filePath, $"{message}\n");
            File.AppendAllText(filePath, "______________________________________________\n");


        }
    }
}