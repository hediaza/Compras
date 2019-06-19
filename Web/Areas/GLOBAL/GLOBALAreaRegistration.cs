using System.Web.Mvc;

namespace Web.Areas.GLOBAL
{
    public class GLOBALAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GLOBAL";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GLOBAL_default",
                "GLOBAL/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}