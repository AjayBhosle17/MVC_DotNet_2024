namespace _11_Validations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: true, maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: true, maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "FaceBookProfileUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "FaceBookProfileUrl", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
        }
    }
}
