using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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
			var token = GetAPIToken(fornecedor).Result;

			using (var client = new HttpClient())
			{
				var uri = new Uri(fornecedor.UrlEndpointApi);
				client.BaseAddress = new Uri(fornecedor.UrlEndpointApi.Replace(uri.LocalPath, ""));
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

				var response = client.GetAsync($"{uri.LocalPath}/produtos").GetAwaiter().GetResult();
				Debug.WriteLine(54 + "");
				return await response.Content.ReadAsStringAsync();
			}
		}

		public async Task<List<ProdutoFornecedorDTO>> ListarProdutos(Fornecedor fornecedor)
		{
			var produtos = await GetRequest(fornecedor);
			var produtoDTOSet = JsonConvert.DeserializeObject<List<ProdutoFornecedorDTO>>(produtos);
			return produtoDTOSet;
		}
	}
}