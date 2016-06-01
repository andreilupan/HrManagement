namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryInsteadOfLogoUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Employee", "LogoUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "LogoUrl", c => c.String());
            DropColumn("dbo.Employee", "Salary");
        }
    }
}
