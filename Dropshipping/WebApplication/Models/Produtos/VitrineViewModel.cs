using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Models.Produtos
{
	public class VitrineViewModel
	{
		public ProdutoViewModel ProdutoEmDestaque => Produtos.FirstOrDefault();
		public List<ProdutoViewModel> ProdutoEmDestaqueSet => Produtos.Skip(4).Take(4).ToList();
		public List<ProdutoViewModel> ProdutoMaisRecenteSet => Produtos.Take(4).ToList();
		public List<ProdutoViewModel> Produtos { get; set; }
	}
}