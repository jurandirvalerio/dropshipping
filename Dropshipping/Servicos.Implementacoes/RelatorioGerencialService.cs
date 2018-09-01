using System;
using System.Collections.Generic;
using System.Diagnostics;
using DTOs;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class RelatorioGerencialService : IRelatorioGerencialService
	{
		private readonly IClienteService _clienteService;
		private readonly IProdutoService _produtoService;
		private readonly IPedidoService _pedidoService;

		public RelatorioGerencialService(IClienteService clienteService, IProdutoService produtoService, IPedidoService pedidoService)
		{
			_clienteService = clienteService;
			_produtoService = produtoService;
			_pedidoService = pedidoService;
		}

		public void GerarDadosGerenciaisParaEnvio()
		{
			GerarRelatoriosNovosClientes();
			GerarRelatoriosNovosProdutos();
			GerarRelatoriosVendas();
		}

		private void EnviarNovosProdutos(List<ProdutoCadastroDTO> produtoCadastroDtoSet)
		{
			throw new NotImplementedException();
		}

		private void GravarNovosProdutos(List<ProdutoCadastroDTO> produtoCadastroDtoSet)
		{
			throw new NotImplementedException();
		}

		private void GerarRelatoriosVendas()
		{
			var pedidosRealizadosOntem = _pedidoService.ListarPedidosRealizadosOntem();
			if (pedidosRealizadosOntem == null || pedidosRealizadosOntem.Count == 0) return;

			GravarNovasVendas(pedidosRealizadosOntem);
			Enviar(pedidosRealizadosOntem);
		}

		private void GerarRelatoriosNovosProdutos()
		{
			var produtosCadastradosOntem = _produtoService.ListarProdutosCadastradosOntem();
			if (produtosCadastradosOntem == null || produtosCadastradosOntem.Count == 0) return;

			GravarNovosProdutos(produtosCadastradosOntem);
			Enviar(produtosCadastradosOntem);
		}

		private void GerarRelatoriosNovosClientes()
		{
			var clientes = _clienteService.ListarClientesCadastradosOntem();
			if(clientes == null || clientes.Count == 0) return;

			GravarNovosClientes(clientes);
			Enviar(clientes);
		}

		private void GravarNovosClientes(List<ClienteDTO> clientes)
		{
			throw new NotImplementedException();
		}

		private void Enviar(List<PedidoDTO> pedidosRealizadosOntem)
		{
			throw new NotImplementedException();
		}

		private void GravarNovasVendas(List<PedidoDTO> pedidosRealizadosOntem)
		{
			throw new NotImplementedException();
		}

		private void Enviar(List<ClienteDTO> clientesCadastradosOntem)
		{
			throw new NotImplementedException();
		}
		private void Enviar(List<ProdutoCadastroDTO> produtosCadastradosOntem)
		{
			throw new NotImplementedException();
		}

		public void Ok()
		{
			Debug.WriteLine("Ok");
		}
	}
}