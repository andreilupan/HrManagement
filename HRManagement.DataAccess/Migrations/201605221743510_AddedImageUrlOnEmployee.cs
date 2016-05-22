namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageUrlOnEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "ImageUrl");
        }
    }
}
