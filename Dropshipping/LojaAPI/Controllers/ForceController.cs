using System.Web.Http;
using Servicos.Contratos;

namespace LojaAPI.Controllers
{
	public class ForceController : ApiController
	{
		private readonly IRelatorioGerencialService _relatorioGerencialService;

		public ForceController(IRelatorioGerencialService relatorioGerencialService)
		{
			_relatorioGerencialService = relatorioGerencialService;
		}

		public string Get()
		{
			_relatorioGerencialService.GerarDadosGerenciaisParaEnvio();
			return "Ok";
		}
	}
}