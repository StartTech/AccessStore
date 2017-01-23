namespace AccessStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Orders", newName: "Order");
            AddColumn("dbo.OrderItems", "Order_Id", c => c.Guid());
            AlterColumn("dbo.Customer", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Product", "Title", c => c.String(nullable: false, maxLength: 80));
            CreateIndex("dbo.OrderItems", "Order_Id");
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Order", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Order");
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            AlterColumn("dbo.Product", "Title", c => c.String());
            AlterColumn("dbo.Customer", "Name", c => c.String());
            DropColumn("dbo.OrderItems", "Order_Id");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Customer", newName: "Customers");
        }
    }
}
