namespace GrupoFortes.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteradoProduto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "ValordoProduto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "ValordoProduto", c => c.Double(nullable: false));
        }
    }
}
