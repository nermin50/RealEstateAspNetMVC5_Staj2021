namespace RealEstateAspNetMVC5_Staj2021.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablolarolusturdu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        AdvId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        NumOfRoom = c.String(),
                        NumOfBath = c.String(),
                        Credit = c.Boolean(nullable: false),
                        Area = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        Feature = c.String(),
                        Telephone = c.String(),
                        Addres = c.String(),
                        CityId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        NeighborhoodId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdvId)
                .ForeignKey("dbo.Neighborhoods", t => t.NeighborhoodId, cascadeDelete: true)
                .ForeignKey("dbo.Tips", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.NeighborhoodId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.AdvPhotoes",
                c => new
                    {
                        AdvPhotoId = c.Int(nullable: false, identity: true),
                        AdvPhotoName = c.String(),
                        AdvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdvPhotoId)
                .ForeignKey("dbo.Advertisements", t => t.AdvId, cascadeDelete: true)
                .Index(t => t.AdvId);
            
            CreateTable(
                "dbo.Neighborhoods",
                c => new
                    {
                        NeighborhoodId = c.Int(nullable: false, identity: true),
                        NeighborhoodName = c.String(),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NeighborhoodId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisements", "TypeId", "dbo.Tips");
            DropForeignKey("dbo.Advertisements", "NeighborhoodId", "dbo.Neighborhoods");
            DropForeignKey("dbo.Neighborhoods", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AdvPhotoes", "AdvId", "dbo.Advertisements");
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropIndex("dbo.Neighborhoods", new[] { "DistrictId" });
            DropIndex("dbo.AdvPhotoes", new[] { "AdvId" });
            DropIndex("dbo.Advertisements", new[] { "TypeId" });
            DropIndex("dbo.Advertisements", new[] { "NeighborhoodId" });
            DropTable("dbo.Cities");
            DropTable("dbo.Districts");
            DropTable("dbo.Neighborhoods");
            DropTable("dbo.AdvPhotoes");
            DropTable("dbo.Advertisements");
        }
    }
}
