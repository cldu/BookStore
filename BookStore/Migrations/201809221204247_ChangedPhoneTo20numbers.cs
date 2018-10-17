namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPhoneTo20numbers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
        }
    }
}
