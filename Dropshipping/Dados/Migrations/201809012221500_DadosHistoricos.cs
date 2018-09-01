namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DadosHistoricos : DbMigration
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
            DropTable("dbo.ProdutoHistorico");
            DropTable("dbo.PedidoHistorico");
            DropTable("dbo.ItemPedidoHistorico");
            DropTable("dbo.ClienteHistorico");
        }
    }
}
