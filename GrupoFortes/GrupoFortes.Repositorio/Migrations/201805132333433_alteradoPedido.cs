namespace GrupoFortes.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteradoPedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "deletado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido", "deletado");
        }
    }
}
