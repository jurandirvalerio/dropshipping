using DTOs;
using Entidades;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class PedidoMapper :IPedidoMapper
	{
		public Pedido Map(PedidoDTO pedidoDto)
		{
			return new Pedido
			{
				Bairro = pedidoDto.Bairro,
				CEP = pedidoDto.CEP,
				CPF = pedidoDto.CPF,
				Endereco = pedidoDto.Endereco,
				Cidade = pedidoDto.Cidade,
				Nome = pedidoDto.Nome,
				Telefone = pedidoDto.Telefone
			};
		}
	}
}