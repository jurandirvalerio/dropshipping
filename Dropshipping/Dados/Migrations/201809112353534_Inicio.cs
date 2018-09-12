namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClienteHistorico",
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
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UrlEndpointApi = c.String(),
                        UsuarioApi = c.String(),
                        SenhaApi = c.String(),
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
                        PrecoVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoFornecedor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GuidProdutoFornecedor = c.Guid(nullable: false),
                        Estoque = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.ItemPedidoHistorico",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Nome = c.String(),
                        PrecoFornecedor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fornecedor = c.String(),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.PedidoHistorico",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(),
                        Nome = c.String(),
                        CPF = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        CEP = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalFornecedor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LucroLiquido = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GuidCliente = c.String(),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        CodigoCliente = c.Int(nullable: false),
                        Nome = c.String(),
                        CPF = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        CEP = c.String(),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cliente", t => t.CodigoCliente, cascadeDelete: true)
                .Index(t => t.CodigoCliente);
            
            CreateTable(
                "dbo.PedidoItem",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CodigoProduto = c.Int(nullable: false),
                        CodigoFornecedor = c.Int(nullable: false),
                        PrecoFornecedor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoCliente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                        CodigoPedido = c.Int(nullable: false),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Fornecedor", t => t.CodigoFornecedor, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.CodigoPedido, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.CodigoProduto, cascadeDelete: true)
                .Index(t => t.CodigoProduto)
                .Index(t => t.CodigoFornecedor)
                .Index(t => t.CodigoPedido);
            
            CreateTable(
                "dbo.ProdutoHistorico",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        PrecoCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fornecedor = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        Visivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoItem", "CodigoProduto", "dbo.Produto");
            DropForeignKey("dbo.PedidoItem", "CodigoPedido", "dbo.Pedido");
            DropForeignKey("dbo.PedidoItem", "CodigoFornecedor", "dbo.Fornecedor");
            DropForeignKey("dbo.Pedido", "CodigoCliente", "dbo.Cliente");
            DropForeignKey("dbo.ProdutoFornecedor", "CodigoProduto", "dbo.Produto");
            DropForeignKey("dbo.UrlImagem", "Produto_Codigo", "dbo.Produto");
            DropForeignKey("dbo.ProdutoFornecedor", "CodigoFornecedor", "dbo.Fornecedor");
            DropIndex("dbo.PedidoItem", new[] { "CodigoPedido" });
            DropIndex("dbo.PedidoItem", new[] { "CodigoFornecedor" });
            DropIndex("dbo.PedidoItem", new[] { "CodigoProduto" });
            DropIndex("dbo.Pedido", new[] { "CodigoCliente" });
            DropIndex("dbo.UrlImagem", new[] { "Produto_Codigo" });
            DropIndex("dbo.ProdutoFornecedor", new[] { "CodigoFornecedor" });
            DropIndex("dbo.ProdutoFornecedor", new[] { "CodigoProduto" });
            DropTable("dbo.ProdutoHistorico");
            DropTable("dbo.PedidoItem");
            DropTable("dbo.Pedido");
            DropTable("dbo.PedidoHistorico");
            DropTable("dbo.ItemPedidoHistorico");
            DropTable("dbo.UrlImagem");
            DropTable("dbo.Produto");
            DropTable("dbo.ProdutoFornecedor");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Cliente");
            DropTable("dbo.ClienteHistorico");
        }
    }
}
