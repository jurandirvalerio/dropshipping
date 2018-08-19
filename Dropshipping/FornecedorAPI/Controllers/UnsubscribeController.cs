using System.Net;
using System.Net.Http;
using System.Web.Http;
using FornecedorAPI.Models;

namespace FornecedorAPI.Controllers
{
	/// <summary>
	/// Controller para cancelar subscrições
	/// </summary>
	public class UnsubscribeController : ApiController
	{
		/// <summary>
		/// Subscrever ao produto para receber atualizações de preço e estoque
		/// </summary>
		/// <param name="publisherSubscriber"></param>
		/// <returns></returns>
		[HttpPost]
		public HttpResponseMessage Unsubscribe(PublisherSubscriber publisherSubscriber)
		{
			return publisherSubscriber == null
				? new HttpResponseMessage(HttpStatusCode.BadRequest)
				: new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}