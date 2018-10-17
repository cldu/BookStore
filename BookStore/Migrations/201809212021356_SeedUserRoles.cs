namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('5882744f-7182-4136-809c-7afcc4bbd844', '299261e5-0ab7-415f-be6e-a641def72e0e')");
        }

        public override void Down()
        {
        }
    }
}
