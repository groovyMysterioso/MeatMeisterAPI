namespace MeatMeisterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeefOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RancherName = c.String(),
                        RancherPhoneNumber = c.String(),
                        Shoulders = c.String(),
                        Steaks = c.String(),
                        Ribs = c.String(),
                        Brisket = c.String(),
                        SirloinTips = c.String(),
                        MeatOrderID = c.Int(),
                        CustomerName = c.String(),
                        CustomerPhoneNumber = c.String(),
                        Loins = c.String(),
                        Rounds = c.String(),
                        Trim = c.String(),
                        Notes = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MeatOrders", t => t.MeatOrderID)
                .Index(t => t.MeatOrderID);
            
            CreateTable(
                "dbo.MeatOrders",
                c => new
                    {
                        MeatOrderID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerPhoneNumber = c.String(),
                        RancherName = c.String(),
                        Notes = c.String(),
                        OrderType = c.Int(nullable: false),
                        KillDate = c.DateTime(),
                        Loins = c.String(),
                        Rounds = c.String(),
                        Trim = c.String(),
                    })
                .PrimaryKey(t => t.MeatOrderID);
            
            CreateTable(
                "dbo.DeerElkOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameOnTag = c.String(nullable: false),
                        Steaks = c.String(),
                        Ribs = c.String(),
                        MeatOrderID = c.Int(),
                        CustomerName = c.String(),
                        CustomerPhoneNumber = c.String(),
                        KillDate = c.DateTime(),
                        Loins = c.String(),
                        Rounds = c.String(),
                        Trim = c.String(),
                        Notes = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MeatOrders", t => t.MeatOrderID)
                .Index(t => t.MeatOrderID);
            
            CreateTable(
                "dbo.HogOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RancherName = c.String(),
                        RancherPhoneNumber = c.String(),
                        Shoulders = c.String(),
                        Hocks = c.String(),
                        Ribs = c.String(),
                        MeatOrderID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MeatOrders", t => t.MeatOrderID)
                .Index(t => t.MeatOrderID);
            
            CreateTable(
                "dbo.SheepOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RancherPhoneNumber = c.String(nullable: false),
                        Shoulders = c.String(),
                        Ribs = c.String(),
                        Shanks = c.String(),
                        MeatOrderID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MeatOrders", t => t.MeatOrderID)
                .Index(t => t.MeatOrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SheepOrders", "MeatOrderID", "dbo.MeatOrders");
            DropForeignKey("dbo.HogOrders", "MeatOrderID", "dbo.MeatOrders");
            DropForeignKey("dbo.DeerElkOrders", "MeatOrderID", "dbo.MeatOrders");
            DropForeignKey("dbo.BeefOrders", "MeatOrderID", "dbo.MeatOrders");
            DropIndex("dbo.SheepOrders", new[] { "MeatOrderID" });
            DropIndex("dbo.HogOrders", new[] { "MeatOrderID" });
            DropIndex("dbo.DeerElkOrders", new[] { "MeatOrderID" });
            DropIndex("dbo.BeefOrders", new[] { "MeatOrderID" });
            DropTable("dbo.SheepOrders");
            DropTable("dbo.HogOrders");
            DropTable("dbo.DeerElkOrders");
            DropTable("dbo.MeatOrders");
            DropTable("dbo.BeefOrders");
        }
    }
}
