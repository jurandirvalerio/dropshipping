namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "Nome", c => c.String());
            DropColumn("dbo.Pedido", "PrimeiroNome");
            DropColumn("dbo.Pedido", "Sobrenome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedido", "Sobrenome", c => c.String());
            AddColumn("dbo.Pedido", "PrimeiroNome", c => c.String());
            DropColumn("dbo.Pedido", "Nome");
        }
    }
}
