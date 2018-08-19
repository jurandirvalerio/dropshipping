using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FornecedorAPI.Models;

namespace FornecedorAPI.Controllers
{
	/// <summary>
	/// Interface para consulta de produtos
	/// </summary>
	[Authorize]
	public class ProdutosController : ApiController
    {
        /// <summary>
		/// Listagem de todos os produtos disponíveis
		/// </summary>
		/// <returns></returns>
        public IEnumerable<Produto> Get()
        {
	        return Produtos();
        }
	    
		/// <summary>
		/// Informações sobre um produto específico
		/// </summary>
		/// <param name="guid">Identificador do produto</param>
		/// <returns></returns>
        public Produto Get(string guid)
        {
	        return Produtos().FirstOrDefault(p => p.Guid == new Guid(guid));
        }

	    private static IEnumerable<Produto> Produtos()
	    {
		    return ProdutoFakeRepository.ListarProdutos();
	    }
	}
}