namespace Company.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emp_Id = c.Int(nullable: false),
                        Emp_Name = c.String(nullable: false),
                        Emp_Department = c.String(nullable: false),
                        MonthlySalary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
