using System.Web.Mvc;

namespace Loja.Areas.Administracao
{
    public class AdministracaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Administracao";

	    public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administracao_default",
                "Administracao/{controller}/{action}/{id}",
                new { controller = "home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}