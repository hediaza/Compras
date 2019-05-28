using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Web {

    public static class HMTLHelperExtensions {
        public static string IsSelected(this HtmlHelper html, string action = null, string controller = null, string area = null, string cssClass = null) {
            string currentArea = null;

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"].ToString();
            string currentController = (string)html.ViewContext.RouteData.Values["controller"].ToString();

            try {
                currentArea = (string)html.ViewContext.RouteData.DataTokens["area"].ToString();
            } catch {
                // no disponible fuera de las areas
            }

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            if (String.IsNullOrEmpty(area))
                area = currentArea;

            return (controller == currentController && action == currentAction && area == currentArea) ? cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html) {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }
    }
}
