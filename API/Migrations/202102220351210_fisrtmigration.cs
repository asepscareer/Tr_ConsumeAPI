namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fisrtmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Account",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb_M_Employee", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tb_M_Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        JoinDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Account", "Id", "dbo.Tb_M_Employee");
            DropIndex("dbo.Tb_M_Account", new[] { "Id" });
            DropTable("dbo.Tb_M_Employee");
            DropTable("dbo.Tb_M_Account");
        }
    }
}
