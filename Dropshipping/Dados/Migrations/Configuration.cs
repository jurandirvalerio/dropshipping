using System.Collections.Generic;
using System.Linq;
using Entidades;

namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

		// SEED para aplicar carga inicial a base de dados
        protected override void Seed(LojaDbContext context)
		{
			CadastrarFornecedor(context);
		}

	    private void CadastrarFornecedor(LojaDbContext context)
		{
			context.FornecedorSet.AddOrUpdate(new Fornecedor
			{
				Codigo = 1,
				Nome = "B2D Fornecedora",
				UsuarioApi = "chefsuser",
				SenhaApi = "chefspassword",
				DataCriacao = DateTime.Now,
				UrlEndpointApi = "http://localhost/fornecedorapi/api",
				Visivel = true
			});
		}
	}
}