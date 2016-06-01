namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLevelOfEcperience : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Position", "LevelOfExperience", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Position", "LevelOfExperience");
        }
    }
}
