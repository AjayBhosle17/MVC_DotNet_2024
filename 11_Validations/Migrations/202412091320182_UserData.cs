namespace _11_Validations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        FaceBookProfileUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
