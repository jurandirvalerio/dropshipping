using DTOs;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusinessIntelligenceAPI.Controllers
{
	[Authorize]
	public class PedidoController : ApiController
	{
		[HttpPost]
		public HttpResponseMessage Post(List<PedidoDTO> pedidoDtoSet)
		{
			return pedidoDtoSet == null
				? new HttpResponseMessage(HttpStatusCode.BadRequest)
				: new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}