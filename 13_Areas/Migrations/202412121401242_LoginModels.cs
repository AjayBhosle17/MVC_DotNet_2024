namespace _13_Areas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginModels",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginModels");
        }
    }
}
