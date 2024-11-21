using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Razor.Utility
{
    public static class CustomUtilityHelper
    {
        public static MvcHtmlString Button(this HtmlHelper htmlHelper , string type,string value)
        {
            //build tag

            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", type);
            input.Attributes.Add("value", value);

            return new MvcHtmlString(input.ToString());

        }

    }
}