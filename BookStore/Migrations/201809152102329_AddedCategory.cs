namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "PublishedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "NumberInStock", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "CategoryId");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropColumn("dbo.Books", "NumberInStock");
            DropColumn("dbo.Books", "AddedDate");
            DropColumn("dbo.Books", "PublishedDate");
            DropColumn("dbo.Books", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
