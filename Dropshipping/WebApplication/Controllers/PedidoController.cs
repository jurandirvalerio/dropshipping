using System.Web.Mvc;
using AutoMapper;
using DTOs;
using Loja.Models.Pedido;
using Microsoft.AspNet.Identity;
using Servicos.Contratos;

namespace Loja.Controllers
{
	[Authorize]
    public class PedidoController : Controller
	{
		private readonly IPedidoService _pedidoService;

		public PedidoController(IPedidoService pedidoService)
		{
			_pedidoService = pedidoService;
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public JsonResult Confirmar(PedidoViewModel pedidoViewModel)
		{
			var pedidoDTO = Mapper.Map<PedidoDTO>(pedidoViewModel);
			pedidoDTO.GuidCliente = User.Identity.GetUserId();
			_pedidoService.Confirmar(pedidoDTO);
		    return Json(true);
	    }
    }
}