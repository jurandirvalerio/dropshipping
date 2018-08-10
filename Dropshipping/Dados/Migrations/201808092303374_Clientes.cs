namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        Nome = c.String(),
                        CPF = c.String(),
                        Email = c.String(),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
