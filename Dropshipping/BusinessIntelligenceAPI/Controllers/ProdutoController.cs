using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTOs;

namespace BusinessIntelligenceAPI.Controllers
{
	[Authorize]
	public class ProdutoController : ApiController
	{
		[HttpPost]
		public HttpResponseMessage Post(List<ProdutoCadastroDTO> produtoCadastradoDtoSet)
		{
			return produtoCadastradoDtoSet == null
				? new HttpResponseMessage(HttpStatusCode.BadRequest)
				: new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}