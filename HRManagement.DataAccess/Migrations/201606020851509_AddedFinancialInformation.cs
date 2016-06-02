namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFinancialInformation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "FinancialInformation_Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employee", "FinancialInformation_NextSalaryIncrease", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employee", "FinancialInformation_AccountNumber", c => c.String());
            AddColumn("dbo.Employee", "FinancialInformation_Bank", c => c.String());
            DropColumn("dbo.Employee", "Salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Employee", "FinancialInformation_Bank");
            DropColumn("dbo.Employee", "FinancialInformation_AccountNumber");
            DropColumn("dbo.Employee", "FinancialInformation_NextSalaryIncrease");
            DropColumn("dbo.Employee", "FinancialInformation_Salary");
        }
    }
}
