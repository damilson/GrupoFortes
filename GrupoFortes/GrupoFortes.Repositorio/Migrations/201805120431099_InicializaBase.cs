namespace GrupoFortes.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicializaBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        FornecedorId = c.Int(nullable: false, identity: true),
                        NomeContato = c.String(),
                        EmailContato = c.String(),
                        RazaoSocial = c.String(),
                        CNPJ = c.String(),
                        UF = c.String(),
                    })
                .PrimaryKey(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        CodigoDoPedido = c.Int(nullable: false),
                        DataDoPedido = c.String(),
                        QuantidadeDeProdutos = c.Int(nullable: false),
                        ValorTotalDoPedido = c.Double(nullable: false),
                        Fornecedor_FornecedorId = c.Int(),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Fornecedor", t => t.Fornecedor_FornecedorId)
                .Index(t => t.Fornecedor_FornecedorId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        CodigoProduto = c.Int(nullable: false),
                        Descricao = c.String(),
                        DataDoCadastro = c.DateTime(nullable: false),
                        ValordoProduto = c.Double(nullable: false),
                        Pedido_PedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Pedido", t => t.Pedido_PedidoId)
                .Index(t => t.Pedido_PedidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Pedido_PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "Fornecedor_FornecedorId", "dbo.Fornecedor");
            DropIndex("dbo.Produto", new[] { "Pedido_PedidoId" });
            DropIndex("dbo.Pedido", new[] { "Fornecedor_FornecedorId" });
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
            DropTable("dbo.Fornecedor");
        }
    }
}
