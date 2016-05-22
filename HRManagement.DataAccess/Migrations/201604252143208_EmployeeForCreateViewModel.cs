namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeForCreateViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Languages", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Languages");
        }
    }
}
