using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Loja.Models.Pedido;
using Servicos.Contratos;

namespace Loja.Controllers
{
	[Authorize]
	public class MeusPedidosController : Controller
	{
		private readonly IPedidoService _pedidoService;
		private readonly IClienteService _clienteService;

		public MeusPedidosController(IPedidoService pedidoService, IClienteService clienteService)
		{
			_pedidoService = pedidoService;
			_clienteService = clienteService;
		}

		public ActionResult Index()
		{
			var pedidoDTOSet = _pedidoService.Listar(_clienteService.ObterCodigoCliente(HttpContext.User.Identity.Name));
			return View(Mapper.Map<List<PedidoViewModel>>(pedidoDTOSet));
		}
	}
}