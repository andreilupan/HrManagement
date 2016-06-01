namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreonPositions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Position", "Technology", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Position", "Technology");
        }
    }
}
