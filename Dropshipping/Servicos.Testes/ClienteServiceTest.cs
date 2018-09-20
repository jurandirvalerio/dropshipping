using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entidades;
using Moq;
using NUnit.Framework;
using Repositorios.Contratos;
using Servicos.Contratos;
using Servicos.Implementacoes;
 
namespace Servicos.Testes
{
	[TestFixture]
	public class ClienteServiceTest
	{
		private Mock<IClienteRepository> _clienteRepository;
		private Mock<IClienteHistoricoRepository> _clienteHistoricoRepository;
		private IClienteService _clienteService;

		[SetUp]
		public void Setup()
		{
			_clienteRepository = new Mock<IClienteRepository>();
			_clienteHistoricoRepository = new Mock<IClienteHistoricoRepository>();

			_clienteService = new ClienteService(_clienteRepository.Object, _clienteHistoricoRepository.Object);
			SetupClienteRepository();
			SetupClienteHistoricoRepository();
		}

		private void SetupClienteHistoricoRepository()
		{
			var clienteHistoricoSet = new List<ClienteHistorico>()
			{
				new ClienteHistorico()
				{
					Nome = "Nome cliente",
					CPF = "123.213.456-78",
					Codigo = 1,
					DataAtualizacao = new DateTime(2011, 1, 1),
					DataCriacao = new DateTime(2010, 1, 1),
					Email = "email@fake.com",
					Guid = Guid.NewGuid(),
					Visivel = true
				}
			};

			_clienteHistoricoRepository.Setup(x => x.FindBy(It.IsAny<Expression<Func<ClienteHistorico, bool>>>())).Returns(clienteHistoricoSet.AsQueryable());
			_clienteHistoricoRepository.Setup(x => x.Add(It.IsAny<ClienteHistorico>()));
			_clienteHistoricoRepository.Setup(x => x.Save());
		}

		private void SetupClienteRepository()
		{
			var clienteSet = new List<Cliente>()
			{
				new Cliente()
				{
					Nome = "Nome cliente",
					CPF = "123.213.456-78",
					Codigo = 1,
					DataAtualizacao = new DateTime(2011, 1, 1),
					DataCriacao = new DateTime(2010, 1, 1),
					Email = "email@fake.com",
					Guid = Guid.NewGuid(),
					Visivel = true
				}
			};

			_clienteRepository.Setup(x => x.FindBy(It.IsAny<Expression<Func<Cliente, bool>>>())).Returns(clienteSet.AsQueryable());
			_clienteRepository.Setup(x => x.Add(It.IsAny<Cliente>()));
			_clienteRepository.Setup(x => x.Save());
		}

		[Test]
		public void ObterNomeClienteTest()
		{
			// Arrange
			var expected = "Nome cliente";

			// Act
			var actual = _clienteService.ObterNomeCliente("email@fake.com");

			// Assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void ObterCodigoClienteTest()
		{
			// Arrange
			var expected = 1;

			// Act
			var actual = _clienteService.ObterCodigoCliente("email@fake.com");

			// Assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void CadastrarTest()
		{
			// Arrange
			var cliente = new Cliente() { Codigo = 1, Nome = "Nome fake" };

			// Act
			// Assert
			Assert.DoesNotThrow(() => _clienteService.Cadastrar(cliente));
		}

		[Test]
		public void CadastrarHistoricoTest()
		{
			// Arrange
			var cliente = new ClienteHistorico() { Codigo = 1, Nome = "Nome fake" };

			// Act
			// Assert
			Assert.DoesNotThrow(() => _clienteService.CadastrarHistorico(cliente));
		}

		[Test]
		public void ListarClientesCadastradosOntemTest()
		{
			// Arrange
			var expected = 1;

			// Act
			var actual = _clienteService.ListarClientesCadastradosOntem();

			// Assert
			Assert.That(actual, Is.Not.Null);
			Assert.That(actual.Count, Is.EqualTo(expected));
		}

		[Test]
		public void JaEnviouDadosAoBIHojeTest()
		{
			// Arrange
			var expected = true;

			// Act
			var actual = _clienteService.JaEnviouDadosAoBIHoje();

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

	}
}