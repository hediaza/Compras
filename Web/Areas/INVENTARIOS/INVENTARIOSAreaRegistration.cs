using System.Web.Mvc;

namespace Web.Areas.INVENTARIOS
{
    public class INVENTARIOSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "INVENTARIOS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "INVENTARIOS_default",
                "INVENTARIOS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}