using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _14_Filters.CustomFilter
{
    /*  public class CustomErrorHandleAttribute:HandleErrorAttribute
      {
          public override void OnException(ExceptionContext filterContext)
          {
              base.OnException(filterContext);
          }
      }*/

    public class CustomErrorHandleAttribute :FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //to log exception details in databse we can ge all information about exception
            var controllerName= filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            Exception exception=filterContext.Exception;
            var ExcepMessage = exception.Message;

            // we can store this info in db error log table

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };

            filterContext.ExceptionHandled = true;

        }
    }


}