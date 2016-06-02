namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFinancialInformation2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinancialInformation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NextSalaryIncrease = c.DateTime(nullable: false),
                        AccountNumber = c.String(),
                        Bank = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employee", "FinancialInformation_Id", c => c.Int());
            CreateIndex("dbo.Employee", "FinancialInformation_Id");
            AddForeignKey("dbo.Employee", "FinancialInformation_Id", "dbo.FinancialInformation", "Id");
            DropColumn("dbo.Employee", "FinancialInformation_Salary");
            DropColumn("dbo.Employee", "FinancialInformation_NextSalaryIncrease");
            DropColumn("dbo.Employee", "FinancialInformation_AccountNumber");
            DropColumn("dbo.Employee", "FinancialInformation_Bank");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "FinancialInformation_Bank", c => c.String());
            AddColumn("dbo.Employee", "FinancialInformation_AccountNumber", c => c.String());
            AddColumn("dbo.Employee", "FinancialInformation_NextSalaryIncrease", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employee", "FinancialInformation_Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Employee", "FinancialInformation_Id", "dbo.FinancialInformation");
            DropIndex("dbo.Employee", new[] { "FinancialInformation_Id" });
            DropColumn("dbo.Employee", "FinancialInformation_Id");
            DropTable("dbo.FinancialInformation");
        }
    }
}
