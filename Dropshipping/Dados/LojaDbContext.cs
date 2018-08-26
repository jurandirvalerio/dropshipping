using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entidades;
using Fornecedor = Entidades.Fornecedor;

namespace Dados
{
	using System.Data.Entity;

	public partial class LojaDbContext : DbContext
	{
		public LojaDbContext()
			: base("name=LojaDbContext")
		{
		}

		public DbSet<Produto> ProdutoSet { get; set; }
		public DbSet<UrlImagem> UrlImagemSet { get; set; }
		public DbSet<Fornecedor> FornecedorSet { get; set; }
		public DbSet<Cliente> ClienteSet { get; set; }
		public DbSet<Pedido> PedidoSet { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Properties()
				.Where(p => p.Name == "Codigo")
				.Configure(p => p.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));

			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}