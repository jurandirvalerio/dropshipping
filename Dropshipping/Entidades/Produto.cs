﻿using System.Collections.Generic;

namespace Entidades
{
	public class Produto : Entidade
	{
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public ICollection<UrlImagem> UrlImagemDetalheSet { get; set; }
		public ICollection<PrecoProdutoFornecedor> PrecoProdutoFornecedorSet { get; set; }
	}
}