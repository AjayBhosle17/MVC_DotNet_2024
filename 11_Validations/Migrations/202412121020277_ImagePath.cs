namespace _11_Validations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Image_path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Image_path");
        }
    }
}
