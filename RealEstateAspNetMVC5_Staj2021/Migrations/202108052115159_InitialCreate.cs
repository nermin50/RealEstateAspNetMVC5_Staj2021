namespace RealEstateAspNetMVC5_Staj2021.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Tips",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TypeId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tips", "StatusId", "dbo.Status");
            DropIndex("dbo.Tips", new[] { "StatusId" });
            DropTable("dbo.Tips");
            DropTable("dbo.Status");
        }
    }
}
