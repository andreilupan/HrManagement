namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActivateOnNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "Active");
        }
    }
}
