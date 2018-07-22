using System.Web.Mvc;

namespace WebApplication.Areas.Loja
{
    public class LojaAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Loja";

	    public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Loja_default",
                "Loja/{controller}/{action}/{id}",
                new { controller= "Vitrine", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}	