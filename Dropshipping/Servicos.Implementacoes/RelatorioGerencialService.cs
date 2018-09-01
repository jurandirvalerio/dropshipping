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
		private readonly IClienteMapper _clienteMapper;
		private readonly IProdutoMapper _produtoMapper;
		private readonly IPedidoMapper _pedidoMapper;

		public RelatorioGerencialService(IClienteService clienteService, IProdutoService produtoService, IPedidoService pedidoService, IClienteMapper clienteMapper, IProdutoMapper produtoMapper, IPedidoMapper pedidoMapper)
		{
			_clienteService = clienteService;
			_produtoService = produtoService;
			_pedidoService = pedidoService;
			_clienteMapper = clienteMapper;
			_produtoMapper = produtoMapper;
			_pedidoMapper = pedidoMapper;
		}

		public void GerarDadosGerenciaisParaEnvio()
		{
			GerarRelatoriosNovosClientes();
			GerarRelatoriosNovosProdutos();
			GerarRelatoriosVendas();
		}

		private void GravarNovosProdutos(List<ProdutoCadastroDTO> produtoCadastroDtoSet)
		{
			var produtoHistoricoSet = _produtoMapper.Map(produtoCadastroDtoSet);
			produtoHistoricoSet.ForEach(_produtoService.CadastrarHistorico);
		}

		private void GerarRelatoriosVendas()
		{
			if (_pedidoService.JaEnviouDadosAoBIHoje()) return;
			var pedidosRealizadosOntem = _pedidoService.ListarPedidosRealizadosOntem();
			if (pedidosRealizadosOntem == null || pedidosRealizadosOntem.Count == 0) return;

			GravarNovasVendas(pedidosRealizadosOntem);
			Enviar(pedidosRealizadosOntem);
		}

		private void GerarRelatoriosNovosProdutos()
		{
			if (_produtoService.JaEnviouDadosAoBIHoje()) return;
			var produtosCadastradosOntem = _produtoService.ListarProdutosCadastradosOntem();
			if (produtosCadastradosOntem == null || produtosCadastradosOntem.Count == 0) return;

			GravarNovosProdutos(produtosCadastradosOntem);
			Enviar(produtosCadastradosOntem);
		}

		private void GerarRelatoriosNovosClientes()
		{
			if (_clienteService.JaEnviouDadosAoBIHoje()) return;
			var clientes = _clienteService.ListarClientesCadastradosOntem();
			if(clientes == null || clientes.Count == 0) return;

			GravarNovosClientes(clientes);
			Enviar(clientes);
		}

		private void GravarNovosClientes(List<ClienteDTO> clientes)
		{
			var clienteHistoricoSet = _clienteMapper.Map(clientes);
			clienteHistoricoSet.ForEach(_clienteService.CadastrarHistorico);
		}

		private void GravarNovasVendas(List<PedidoDTO> pedidos)
		{
			var pedidoHistoricoSet = _pedidoMapper.MapPedidoHistorico(pedidos);
			var itemPedidoHistorioSet = _pedidoMapper.MapItemPedidoHistorico(pedidos);
			pedidoHistoricoSet.ForEach(_pedidoService.CadastrarHistorico);
			itemPedidoHistorioSet.ForEach(_pedidoService.CadastrarHistorico);
		}

		private void Enviar(List<ClienteDTO> clientesCadastradosOntem)
		{
			throw new NotImplementedException();
		}
		private void Enviar(List<ProdutoCadastroDTO> produtosCadastradosOntem)
		{
			throw new NotImplementedException();
		}

		private void Enviar(List<PedidoDTO> pedidosRealizadosOntem)
		{
			throw new NotImplementedException();
		}

		public void Ok()
		{
			Debug.WriteLine("Ok");
		}
	}
}