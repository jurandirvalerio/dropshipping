using System.Collections.Generic;
using Entidades;

namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Dados.LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dados.LojaDbContext context)
        {
			context.ProdutoSet.AddOrUpdate(x => x.Codigo,
				new Produto()
				{
					Codigo = 1,
					Descricao = "O Cooktop IC60 é perfeito para quem busca qualidade e sofisticação na hora de cozinhar. Possui 9 níveis de potência, painel touch, timer e a exclusiva função Turbo Potência, que libera até 160% mais potencia por até 10 minutos. Possui ainda uma trava de painel para evitar que a programação seja alterada e a mesa Vitrocerâmica deixa a limpeza mais fácil.",
					Nome = "Cooktop de Indução 4 Queimadores (IC60)",
					Visivel = true,
					DataCriacao = DateTime.Now,
					UrlImagemDetalheSet = new List<UrlImagem>
					{
						new UrlImagem("Content/Imagem/ic60_1.png"),
						new UrlImagem("Content/Imagem/ic60_2.png"),
						new UrlImagem("Content/Imagem/ic60_3.png"),
					}
				});
        }
    }
}