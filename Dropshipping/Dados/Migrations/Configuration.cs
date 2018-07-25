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
					Descricao = "O Cooktop IC60 � perfeito para quem busca qualidade e sofistica��o na hora de cozinhar. Possui 9 n�veis de pot�ncia, painel touch, timer e a exclusiva fun��o Turbo Pot�ncia, que libera at� 160% mais potencia por at� 10 minutos. Possui ainda uma trava de painel para evitar que a programa��o seja alterada e a mesa Vitrocer�mica deixa a limpeza mais f�cil.",
					Nome = "Cooktop de Indu��o 4 Queimadores (IC60)",
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