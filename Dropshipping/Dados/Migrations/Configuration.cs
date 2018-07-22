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
        }
    }
}
