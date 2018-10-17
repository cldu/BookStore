namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'299261e5-0ab7-415f-be6e-a641def72e0e', N'Administrator')");
        }
        
        public override void Down()
        {
        }
    }
}
