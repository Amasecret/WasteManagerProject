namespace AmaraProject.WasteManager.Win.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListingItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WasteItem", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.WasteListing", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.WasteItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 16),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WasteCategory", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.WasteCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WasteListing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SellerId = c.Int(nullable: false),
                        ListingDate = c.DateTime(nullable: false),
                        ListingNo = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WasteSeller", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.SellerId);
            
            CreateTable(
                "dbo.SalesInvoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        InvoiceNo = c.String(nullable: false, maxLength: 20),
                        InvoiceDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WasteBuyer", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.WasteListing", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.WasteBuyer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        BankId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        AccountNo = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bank", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.WasteSeller",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        BankId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        AccountNo = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bank", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.BankId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WasteListing", "SellerId", "dbo.WasteSeller");
            DropForeignKey("dbo.WasteSeller", "LocationId", "dbo.Location");
            DropForeignKey("dbo.WasteSeller", "BankId", "dbo.Bank");
            DropForeignKey("dbo.ListingItem", "ListingId", "dbo.WasteListing");
            DropForeignKey("dbo.SalesInvoice", "ListingId", "dbo.WasteListing");
            DropForeignKey("dbo.WasteBuyer", "LocationId", "dbo.Location");
            DropForeignKey("dbo.SalesInvoice", "BuyerId", "dbo.WasteBuyer");
            DropForeignKey("dbo.WasteBuyer", "BankId", "dbo.Bank");
            DropForeignKey("dbo.ListingItem", "ItemId", "dbo.WasteItem");
            DropForeignKey("dbo.WasteItem", "CategoryId", "dbo.WasteCategory");
            DropIndex("dbo.WasteSeller", new[] { "BankId" });
            DropIndex("dbo.WasteSeller", new[] { "LocationId" });
            DropIndex("dbo.WasteBuyer", new[] { "BankId" });
            DropIndex("dbo.WasteBuyer", new[] { "LocationId" });
            DropIndex("dbo.SalesInvoice", new[] { "BuyerId" });
            DropIndex("dbo.SalesInvoice", new[] { "ListingId" });
            DropIndex("dbo.WasteListing", new[] { "SellerId" });
            DropIndex("dbo.WasteItem", new[] { "CategoryId" });
            DropIndex("dbo.ListingItem", new[] { "ItemId" });
            DropIndex("dbo.ListingItem", new[] { "ListingId" });
            DropTable("dbo.WasteSeller");
            DropTable("dbo.WasteBuyer");
            DropTable("dbo.SalesInvoice");
            DropTable("dbo.WasteListing");
            DropTable("dbo.WasteCategory");
            DropTable("dbo.WasteItem");
            DropTable("dbo.ListingItem");
        }
    }
}
