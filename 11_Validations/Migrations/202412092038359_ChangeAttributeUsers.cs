namespace _11_Validations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAttributeUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
        }
    }
}
