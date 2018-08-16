namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
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
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.ProdutoFornecedor",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CodigoProduto = c.Int(nullable: false),
                        CodigoFornecedor = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Fornecedor", t => t.CodigoFornecedor, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.CodigoProduto, cascadeDelete: true)
                .Index(t => t.CodigoProduto)
                .Index(t => t.CodigoFornecedor);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoFornecedor", "CodigoProduto", "dbo.Produto");
            DropForeignKey("dbo.UrlImagem", "Produto_Codigo", "dbo.Produto");
            DropForeignKey("dbo.ProdutoFornecedor", "CodigoFornecedor", "dbo.Fornecedor");
            DropIndex("dbo.UrlImagem", new[] { "Produto_Codigo" });
            DropIndex("dbo.ProdutoFornecedor", new[] { "CodigoFornecedor" });
            DropIndex("dbo.ProdutoFornecedor", new[] { "CodigoProduto" });
            DropTable("dbo.UrlImagem");
            DropTable("dbo.Produto");
            DropTable("dbo.ProdutoFornecedor");
            DropTable("dbo.Fornecedor");
        }
    }
}
