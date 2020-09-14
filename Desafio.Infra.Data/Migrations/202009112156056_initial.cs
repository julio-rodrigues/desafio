namespace Desafio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.client",
                c => new
                    {
                        ClientId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.product",
                c => new
                    {
                        ProductId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.client", "ProductId", "dbo.product");
            DropIndex("dbo.client", new[] { "ProductId" });
            DropTable("dbo.product");
            DropTable("dbo.client");
        }
    }
}
