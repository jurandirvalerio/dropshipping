namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidPedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "Guid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido", "Guid");
        }
    }
}
