using System.Web.Mvc;

namespace DSJ.Areas.SEG
{
    public class SEGAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SEG";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SEG_default",
                "SEG/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}