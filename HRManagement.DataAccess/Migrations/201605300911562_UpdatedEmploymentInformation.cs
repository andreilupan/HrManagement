namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEmploymentInformation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmploymentInformation", "JubileeDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmploymentInformation", "DateForFormalProfessionalCompetence", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmploymentInformation", "DateForFormalTeachingSkills", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmploymentInformation", "DateForFormalTeachingSkills");
            DropColumn("dbo.EmploymentInformation", "DateForFormalProfessionalCompetence");
            DropColumn("dbo.EmploymentInformation", "JubileeDate");
        }
    }
}
