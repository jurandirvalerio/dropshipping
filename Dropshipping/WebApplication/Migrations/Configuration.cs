using System.Data.Entity.Migrations;
using Loja.Infrastructure.Authentication;

namespace Loja.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<AuthenticationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthenticationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
