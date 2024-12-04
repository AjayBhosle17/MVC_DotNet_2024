namespace _10_Code_First_Approch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryTableUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameColumn(table: "dbo.Category", name: "Name", newName: "Category_Name");
            AlterColumn("dbo.Category", "Category_Name", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Category", "Rating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Category", "Category_Name", c => c.String());
            RenameColumn(table: "dbo.Category", name: "Category_Name", newName: "Name");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
