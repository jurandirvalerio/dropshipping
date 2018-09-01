using System.Web.Http;
using Servicos.Contratos;

namespace LojaAPI.Controllers
{
    public class JobController : ApiController
    {
	    private readonly IJobService _jobService;
	    private readonly IRelatorioGerencialService _relatorioGerencialService;

	    public JobController(IJobService jobService, IRelatorioGerencialService relatorioGerencialService)
	    {
		    _jobService = jobService;
		    _relatorioGerencialService = relatorioGerencialService;
	    }

	    public string Get()
        {
	        _relatorioGerencialService.GerarDadosGerenciaisParaEnvio();
			_jobService.Agendar();
			return "Ok";
		}
    }
}