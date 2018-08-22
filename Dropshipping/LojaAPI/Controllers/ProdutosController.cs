using System.Diagnostics;
using DTOs;
using System.Web.Http;
using Servicos.Contratos;

namespace LojaAPI.Controllers
{
	[Authorize]
	public class ProdutosController : ApiController
	{
		private readonly IProdutoFornecedorService _produtoFornecedorService;

		public ProdutosController(IProdutoFornecedorService produtoFornecedorService)
		{
			_produtoFornecedorService = produtoFornecedorService;
		}

		[HttpPost]
		public void Atualizar(PublisherSubscriberDTO publisherSubscriberDto)
		{
			Debug.WriteLine("Ok");
			Debug.WriteLine(publisherSubscriberDto);
			//_produtoFornecedorService.AtualizarProduto(publisherSubscriberDto);
		}
	}
}