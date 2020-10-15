using System.Web.Mvc;

namespace DSJ.Areas.AG
{
    public class AGAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AG";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AG_default",
                "AG/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}