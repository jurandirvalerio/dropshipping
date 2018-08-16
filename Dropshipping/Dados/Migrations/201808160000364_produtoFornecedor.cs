namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class produtoFornecedor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PrecoProdutoFornecedor", newName: "ProdutoFornecedor");
            AddColumn("dbo.ProdutoFornecedor", "PrecoVenda", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProdutoFornecedor", "PrecoFornecedor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProdutoFornecedor", "GuidProdutoFornecedor", c => c.Guid(nullable: false));
            DropColumn("dbo.ProdutoFornecedor", "Preco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProdutoFornecedor", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ProdutoFornecedor", "GuidProdutoFornecedor");
            DropColumn("dbo.ProdutoFornecedor", "PrecoFornecedor");
            DropColumn("dbo.ProdutoFornecedor", "PrecoVenda");
            RenameTable(name: "dbo.ProdutoFornecedor", newName: "PrecoProdutoFornecedor");
        }
    }
}
