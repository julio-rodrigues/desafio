namespace Desafio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforegkey : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.client", new[] { "ProductId" });
            DropColumn("dbo.client", "ClientId");
            RenameColumn(table: "dbo.client", name: "ProductId", newName: "ClientId");
            DropPrimaryKey("dbo.client");
            AddColumn("dbo.product", "ClientId", c => c.Guid(nullable: false));
            AlterColumn("dbo.client", "ClientId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.client", "ClientId");
            CreateIndex("dbo.client", "ClientId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.client", new[] { "ClientId" });
            DropPrimaryKey("dbo.client");
            AlterColumn("dbo.client", "ClientId", c => c.Guid(nullable: false));
            DropColumn("dbo.product", "ClientId");
            AddPrimaryKey("dbo.client", "ClientId");
            RenameColumn(table: "dbo.client", name: "ClientId", newName: "ProductId");
            AddColumn("dbo.client", "ClientId", c => c.Guid(nullable: false, identity: true));
            CreateIndex("dbo.client", "ProductId");
        }
    }
}
