namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fornecedores : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fornecedor", "UrlEndpointApi", c => c.String());
            AddColumn("dbo.Fornecedor", "UsuarioApi", c => c.String());
            AddColumn("dbo.Fornecedor", "SenhaApi", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fornecedor", "SenhaApi");
            DropColumn("dbo.Fornecedor", "UsuarioApi");
            DropColumn("dbo.Fornecedor", "UrlEndpointApi");
        }
    }
}
