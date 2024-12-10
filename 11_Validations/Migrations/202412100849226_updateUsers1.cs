﻿namespace _11_Validations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsers1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "FaceBookProfileUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "FaceBookProfileUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
