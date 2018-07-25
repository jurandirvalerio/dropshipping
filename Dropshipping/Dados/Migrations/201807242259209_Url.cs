namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Url : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UrlImagem",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Produto_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Produto", t => t.Produto_Codigo)
                .Index(t => t.Produto_Codigo);
            
            DropColumn("dbo.Produto", "UrlImagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "UrlImagem", c => c.String());
            DropForeignKey("dbo.UrlImagem", "Produto_Codigo", "dbo.Produto");
            DropIndex("dbo.UrlImagem", new[] { "Produto_Codigo" });
            DropTable("dbo.UrlImagem");
        }
    }
}
