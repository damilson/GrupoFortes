namespace GrupoFortes.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ialteradodatapedido : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pedido", "DataDoPedido", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pedido", "DataDoPedido", c => c.String());
        }
    }
}
