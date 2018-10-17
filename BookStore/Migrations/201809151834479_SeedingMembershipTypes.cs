namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (MembershipPrice, MonthsDuration, Discount) VALUES (0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (MembershipPrice, MonthsDuration, Discount) VALUES (5, 1, 10)");
            Sql("INSERT INTO MembershipTypes (MembershipPrice, MonthsDuration, Discount) VALUES (20, 6, 20)");
            Sql("INSERT INTO MembershipTypes (MembershipPrice, MonthsDuration, Discount) VALUES (50, 12, 30)");

        }

        public override void Down()
        {
        }
    }
}
