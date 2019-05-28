using System.Web.Mvc;

namespace Web.Areas.COMPRAS
{
    public class COMPRASAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "COMPRAS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "COMPRAS_default",
                "COMPRAS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}