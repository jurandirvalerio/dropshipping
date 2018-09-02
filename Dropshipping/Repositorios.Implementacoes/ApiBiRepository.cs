using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ApiBiRepository : IApiBiRepository
	{
		public void Enviar(List<ProdutoCadastroDTO> produtoCadastradoDtoSet)
		{
			Enviar(produtoCadastradoDtoSet, "produto");
		}

		public void Enviar(List<ClienteDTO> clienteDtoSet)
		{
			Enviar(clienteDtoSet, "cliente");
		}

		public void Enviar(List<PedidoDTO> pedidoDtoSet)
		{
			Enviar(pedidoDtoSet, "pedido");
		}

		private void Enviar(object @object, string controllerName)
		{
			using (var client = new HttpClient())
			{
				var uri = ObterUri(client);
				var json = JsonConvert.SerializeObject(@object);
				var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
				var response = client.PostAsync($"{uri.LocalPath}/{controllerName}", stringContent).GetAwaiter().GetResult();
				response.EnsureSuccessStatusCode();
			}
		}

		private Uri ObterUri(HttpClient client)
		{
			var token = GetAPIToken().Result;
			var url = ObterUrl();
			var uri = new Uri(url);
			client.BaseAddress = new Uri(url.Replace(uri.LocalPath, ""));
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
			return uri;
		}

		private string ObterUrl()
		{
			return ConfigurationManager.AppSettings["urlApiBi"];
		}

		private async Task<string> GetAPIToken()
		{
			using (var client = new HttpClient())
			{
				var url = ObterUrl();
				var uri = new Uri(url);
				client.BaseAddress = new Uri(url.Replace(uri.LocalPath, ""));
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var formContent = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("grant_type", "password"),
					new KeyValuePair<string, string>("username", "chefsuser"),
					new KeyValuePair<string, string>("password", "chefspassword"),
				});

				var responseMessage = client.PostAsync($"{uri.LocalPath}/token", formContent).GetAwaiter().GetResult();
				var responseJson = await responseMessage.Content.ReadAsStringAsync();
				return JObject.Parse(responseJson).GetValue("access_token").ToString();
			}
		}
	}
}