using System.Web.Mvc;

namespace Web.Areas.FACTURACION
{
    public class FACTURACIONAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FACTURACION";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FACTURACION_default",
                "FACTURACION/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}