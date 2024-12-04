namespace _10_Code_First_Approch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTableAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Product", newName: "Products");
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.Products", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Products", "ProductId");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Category");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Price", c => c.Int());
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "ProductId");
            AddPrimaryKey("dbo.Products", "Id");
            RenameTable(name: "dbo.Products", newName: "Product");
        }
    }
}
