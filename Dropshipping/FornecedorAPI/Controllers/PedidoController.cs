using System.Net;
using System.Net.Http;
using System.Web.Http;
using FornecedorAPI.Models;

namespace FornecedorAPI.Controllers
{
    public class PedidoController : ApiController
    {

		[HttpPost]
		public HttpResponseMessage Post(Pedido pedido)
		{
			return pedido == null
				? new HttpResponseMessage(HttpStatusCode.BadRequest)
				: new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}