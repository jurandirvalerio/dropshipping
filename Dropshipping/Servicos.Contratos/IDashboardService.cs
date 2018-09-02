using System.Collections.Generic;
using DTOs;
using Entidades;

namespace Servicos.Contratos
{
	public interface IDashboardService
	{
		int ObterNumeroTotalProdutosHistorico();
		int ObterNumeroTotalVendasHistorico();
		decimal ObterValorTotalBrutoVendasHistorico();
		decimal ObterValorTotalVendasPagasAoFornecedorHistorico();
		int ObterNumeroTotalClientesHistorico();
		List<ItemPedidoHistoricoDTO> ObterItensPedido();
	}
}