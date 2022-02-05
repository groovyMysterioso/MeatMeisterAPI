namespace MeatMeisterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BeefOrders", "isActive", c => c.Boolean());
            AddColumn("dbo.HogOrders", "isActive", c => c.Boolean());
            AddColumn("dbo.SheepOrders", "isActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SheepOrders", "isActive");
            DropColumn("dbo.HogOrders", "isActive");
            DropColumn("dbo.BeefOrders", "isActive");
        }
    }
}
