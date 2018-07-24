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
					UrlImagem = "https://electrolux.vteximg.com.br/arquivos/ids/185063-1000-1000/Cooktop-de-Inducao-4-Queimadores-IC60-1.png?v=636537867976130000",
					Visivel = true,
					DataCriacao = DateTime.Now
				});
        }
    }
}