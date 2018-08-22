namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenomeandoColunaQuantidadeParaEstoque : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProdutoFornecedor", "Estoque", c => c.Int(nullable: false));
            DropColumn("dbo.ProdutoFornecedor", "Quantidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProdutoFornecedor", "Quantidade", c => c.Int(nullable: false));
            DropColumn("dbo.ProdutoFornecedor", "Estoque");
        }
    }
}
