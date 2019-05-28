using System.Web.Mvc;

namespace Web.Areas.TIENDAS
{
    public class TIENDASAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TIENDAS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TIENDAS_default",
                "TIENDAS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}