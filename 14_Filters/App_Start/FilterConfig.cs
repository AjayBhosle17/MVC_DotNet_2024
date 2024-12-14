using _14_Filters.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _14_Filters.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection x)
        {
            x.Add(new CustomErrorHandleAttribute());
            x.Add(new TrackRequestFilterAttribute());
        }
    }
}