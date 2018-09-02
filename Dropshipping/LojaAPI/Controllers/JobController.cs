using System.Web.Http;
using Servicos.Contratos;

namespace LojaAPI.Controllers
{
    public class JobController : ApiController
    {
	    private readonly IJobService _jobService;

	    public JobController(IJobService jobService)
	    {
		    _jobService = jobService;
	    }

	    public string Get()
        {
			_jobService.Agendar();
			return "Ok";
		}
    }
}