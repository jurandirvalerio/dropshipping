using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entidades;

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