using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ApiFornecedorRepository : IApiFornecedorRepository
	{
		private readonly IFornecedorRepository _fornecedorRepository;

		public ApiFornecedorRepository(IFornecedorRepository fornecedorRepository)
		{
			_fornecedorRepository = fornecedorRepository;
		}

		private async Task<string> GetAPIToken(Fornecedor fornecedor)
		{
			using (var client = new HttpClient())
			{
				var uri = new Uri(fornecedor.UrlEndpointApi);
				client.BaseAddress = new Uri(fornecedor.UrlEndpointApi.Replace(uri.LocalPath, ""));
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				//setup login data
				var formContent = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("grant_type", "password"),
					new KeyValuePair<string, string>("username", fornecedor.UsuarioApi),
					new KeyValuePair<string, string>("password", fornecedor.SenhaApi),
				});
				
				var responseMessage = client.PostAsync($"{uri.LocalPath}/token", formContent).GetAwaiter().GetResult();
				var responseJson = await responseMessage.Content.ReadAsStringAsync();
				return JObject.Parse(responseJson).GetValue("access_token").ToString();
			}
		}

		public async Task<string> GetRequest(Fornecedor fornecedor)
		{
			using (var client = new HttpClient())
			{
				var uri = ObterUri(fornecedor, client);
				var response = client.GetAsync($"{uri.LocalPath}/produtos").GetAwaiter().GetResult();
				return await response.Content.ReadAsStringAsync();
			}
		}

		private Uri ObterUri(Fornecedor fornecedor, HttpClient client)
		{
			var token = GetAPIToken(fornecedor).Result;
			var uri = new Uri(fornecedor.UrlEndpointApi);
			client.BaseAddress = new Uri(fornecedor.UrlEndpointApi.Replace(uri.LocalPath, ""));
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
			return uri;
		}

		public async Task<List<ProdutoFornecedorDTO>> ListarProdutos(Fornecedor fornecedor)
		{
			var produtos = await GetRequest(fornecedor);
			return JsonConvert.DeserializeObject<List<ProdutoFornecedorDTO>>(produtos);
		}

		public void Subscrever(ProdutoFornecedor produtoFornecedor)
		{
			PublishSubscribe(produtoFornecedor, "/subscribe");
		}

		public void CancelarSubscricao(ProdutoFornecedor produtoFornecedor)
		{
			PublishSubscribe(produtoFornecedor, "/unsubscribe");
		}

		private Fornecedor ObterFornecedor(ProdutoFornecedor produtoFornecedor)
		{
			return _fornecedorRepository.FindBy(f => f.Codigo == produtoFornecedor.CodigoFornecedor).First();
		}

		private static PublisherSubscriberDTO ObterDto(ProdutoFornecedor produtoFornecedor)
		{
			return new PublisherSubscriberDTO
			{
				Url = UrlApi(),
				Guid = produtoFornecedor.GuidProdutoFornecedor
			};
		}

		private static string UrlApi()
		{
			return $"{ObterUrlPadrao()}/produto";
		}

		private static string ObterUrlPadrao()
		{
			return ConfigurationManager.AppSettings["urlApi"];
		}

		public void PublishSubscribe(ProdutoFornecedor produtoFornecedor, string method)
		{
			using (var client = new HttpClient())
			{
				var fornecedor = ObterFornecedor(produtoFornecedor);
				var uri = ObterUri(fornecedor, client);
				var json = JsonConvert.SerializeObject(ObterDto(produtoFornecedor));
				var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
				var response = client.PostAsync($"{uri.LocalPath}{method}", stringContent).GetAwaiter().GetResult();
				response.EnsureSuccessStatusCode();
			}
		}
	}
}