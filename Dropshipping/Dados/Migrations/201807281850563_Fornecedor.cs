namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fornecedor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                        Produto_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Produto", t => t.Produto_Codigo)
                .Index(t => t.Produto_Codigo);
            
            CreateTable(
                "dbo.PrecoProdutoFornecedor",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CodigoProduto = c.Int(nullable: false),
                        CodigoFornecedor = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                        Fornecedor_Codigo = c.Int(),
                        Produto_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Fornecedor", t => t.Fornecedor_Codigo)
                .ForeignKey("dbo.Produto", t => t.Produto_Codigo)
                .Index(t => t.Fornecedor_Codigo)
                .Index(t => t.Produto_Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fornecedor", "Produto_Codigo", "dbo.Produto");
            DropForeignKey("dbo.PrecoProdutoFornecedor", "Produto_Codigo", "dbo.Produto");
            DropForeignKey("dbo.PrecoProdutoFornecedor", "Fornecedor_Codigo", "dbo.Fornecedor");
            DropIndex("dbo.PrecoProdutoFornecedor", new[] { "Produto_Codigo" });
            DropIndex("dbo.PrecoProdutoFornecedor", new[] { "Fornecedor_Codigo" });
            DropIndex("dbo.Fornecedor", new[] { "Produto_Codigo" });
            DropTable("dbo.PrecoProdutoFornecedor");
            DropTable("dbo.Fornecedor");
        }
    }
}
