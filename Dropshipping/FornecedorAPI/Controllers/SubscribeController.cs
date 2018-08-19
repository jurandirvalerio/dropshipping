using System.Net;
using System.Net.Http;
using System.Web.Http;
using FornecedorAPI.Models;

namespace FornecedorAPI.Controllers
{
    /// <summary>
    /// Controller para subscrições
    /// </summary>
    public class SubscribeController : ApiController
    {
		/// <summary>
		/// Subscrever ao produto para receber atualizações de preço e estoque
		/// </summary>
		/// <param name="publisherSubscriber"></param>
		/// <returns></returns>
		[HttpPost]
	    public HttpResponseMessage Subscribe(PublisherSubscriber publisherSubscriber)
	    {
		    return publisherSubscriber == null
			    ? new HttpResponseMessage(HttpStatusCode.BadRequest)
			    : new HttpResponseMessage(HttpStatusCode.OK);
	    }
	}
}