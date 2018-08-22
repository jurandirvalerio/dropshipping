using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FornecedorAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FornecedorAPI.Controllers
{
	public class ProdutoController : Controller
    {
        
	    public ActionResult Index()
        {
            return View(ProdutoFakeRepository.ListarProdutos());
        }

	    [HttpPost]
	    public ActionResult Index(string guid, string estoque)
	    {
		    if (guid != string.Empty && int.TryParse(estoque, out var numeroEstoque))
		    {
			    PostarAtualizacaoDeEstoque(guid, numeroEstoque);
		    }

		    return RedirectToAction("Index");
	    }

	    public void PostarAtualizacaoDeEstoque(string guid, int estoque)
	    {
		    using (var client = new HttpClient())
		    {
			    var uri = ObterUri(client);
			    var json = JsonConvert.SerializeObject(ObterDto(estoque, guid));
			    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			    var response = client.PostAsync($"{uri.LocalPath}/produtos/atualizar", stringContent).GetAwaiter().GetResult();
			    response.EnsureSuccessStatusCode();
		    }
	    }

	    private PublisherSubscriber ObterDto(int estoque, string guid)
	    {
		    return new PublisherSubscriber
		    {
			    Guid = new Guid(guid),
			    Estoque = estoque,
			    Preco = ObterPreco(guid)
		    };
	    }

	    private decimal ObterPreco(string guid)
	    {
		    return ProdutoFakeRepository.ListarProdutos().Where(p => p.Guid == new Guid(guid)).Select(p => p.Preco).First();
	    }

	    private Uri ObterUri(HttpClient client)
	    {
		    var token = GetAPIToken().Result;
		    var uri = new Uri(ObterUlr());
		    client.BaseAddress = new Uri(ObterUlr().Replace(uri.LocalPath, ""));
		    client.DefaultRequestHeaders.Accept.Clear();
		    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
		    return uri;
	    }

	    private async Task<string> GetAPIToken()
	    {
		    using (var client = new HttpClient())
		    {
			    var uri = new Uri(ObterUlr());
			    client.BaseAddress = new Uri(ObterUlr().Replace(uri.LocalPath, ""));
			    client.DefaultRequestHeaders.Accept.Clear();
			    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			    //setup login data
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

	    private string ObterUlr()
	    {
		    return ConfigurationManager.AppSettings["urlApi"];
	    }
    }
}