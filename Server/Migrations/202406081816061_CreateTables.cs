namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SportEventId = c.Int(nullable: false),
                        PlacementDate = c.DateTime(nullable: false),
                        ClosingDate = c.DateTime(nullable: false),
                        CandiesAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SportEvents", t => t.SportEventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SportEventId);
            
            CreateTable(
                "dbo.SportEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SportEventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SportEvents", t => t.SportEventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SportEventId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Photo = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CandyAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SupportId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supports", t => t.SupportId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SupportId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        Date = c.DateTime(nullable: false),
                        ChatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.ChatId, cascadeDelete: true)
                .Index(t => t.ChatId);
            
            CreateTable(
                "dbo.Supports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupportName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.NewsId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "NewsId", "dbo.News");
            DropForeignKey("dbo.Chats", "UserId", "dbo.Users");
            DropForeignKey("dbo.Chats", "SupportId", "dbo.Supports");
            DropForeignKey("dbo.Messages", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.Candies", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Favourites", "SportEventId", "dbo.SportEvents");
            DropForeignKey("dbo.SportEvents", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Bets", "SportEventId", "dbo.SportEvents");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "NewsId" });
            DropIndex("dbo.Messages", new[] { "ChatId" });
            DropIndex("dbo.Chats", new[] { "UserId" });
            DropIndex("dbo.Chats", new[] { "SupportId" });
            DropIndex("dbo.Candies", new[] { "UserId" });
            DropIndex("dbo.Favourites", new[] { "SportEventId" });
            DropIndex("dbo.Favourites", new[] { "UserId" });
            DropIndex("dbo.SportEvents", new[] { "CategoryId" });
            DropIndex("dbo.Bets", new[] { "SportEventId" });
            DropIndex("dbo.Bets", new[] { "UserId" });
            DropTable("dbo.News");
            DropTable("dbo.Comments");
            DropTable("dbo.Supports");
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
            DropTable("dbo.Candies");
            DropTable("dbo.Users");
            DropTable("dbo.Favourites");
            DropTable("dbo.Categories");
            DropTable("dbo.SportEvents");
            DropTable("dbo.Bets");
        }
    }
}
