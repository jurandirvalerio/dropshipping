using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTOs;

namespace BusinessIntelligenceAPI.Controllers
{
	[Authorize]
	public class ClienteController : ApiController
	{
		[HttpPost]
		public HttpResponseMessage Post(List<ClienteDTO> pedidoDtoSet)
		{
			return pedidoDtoSet == null
				? new HttpResponseMessage(HttpStatusCode.BadRequest)
				: new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}