namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('Sci-Fi')");
            Sql("INSERT INTO Categories (Name) VALUES ('Biography')");
            Sql("INSERT INTO Categories (Name) VALUES ('Children')");
            Sql("INSERT INTO Categories (Name) VALUES ('Computers')");
            Sql("INSERT INTO Categories (Name) VALUES ('Law')");
            Sql("INSERT INTO Categories (Name) VALUES ('Romance')");
            
        }

        public override void Down()
        {
        }
    }
}
