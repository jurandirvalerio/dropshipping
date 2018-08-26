namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CodigoCliente = c.Int(nullable: false),
                        PrimeiroNome = c.String(),
                        Sobrenome = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoItem", "CodigoProduto", "dbo.Produto");
            DropForeignKey("dbo.PedidoItem", "CodigoPedido", "dbo.Pedido");
            DropForeignKey("dbo.PedidoItem", "CodigoFornecedor", "dbo.Fornecedor");
            DropForeignKey("dbo.Pedido", "CodigoCliente", "dbo.Cliente");
            DropIndex("dbo.PedidoItem", new[] { "CodigoPedido" });
            DropIndex("dbo.PedidoItem", new[] { "CodigoFornecedor" });
            DropIndex("dbo.PedidoItem", new[] { "CodigoProduto" });
            DropIndex("dbo.Pedido", new[] { "CodigoCliente" });
            DropTable("dbo.PedidoItem");
            DropTable("dbo.Pedido");
        }
    }
}
