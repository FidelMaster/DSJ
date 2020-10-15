using System.Web.Mvc;

namespace DSJ.Areas.VE
{
    public class VEAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "VE";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "VE_default",
                "VE/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}