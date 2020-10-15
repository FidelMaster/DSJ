using System.Web.Mvc;

namespace DSJ.Areas.CL
{
    public class CLAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CL";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CL_default",
                "CL/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}