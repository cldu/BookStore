namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'09b09d78-e219-455f-b9f1-e2cce7a13f37', N'guest@email.com', 0, N'AF0DgNePwz/uAZawxeeAubvrFnHPBUGB7BE7V4KbWrE6ZzCVia6szAA+iqndm/mAKg==', N'e38a3680-c2a5-4ffe-841e-bcc63c6e164a', NULL, 0, 0, NULL, 1, 0, N'guest@email.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5882744f-7182-4136-809c-7afcc4bbd844', N'admin@email.com', 0, N'AAehma52cQOYwdoJglLIoqtIm9kNGzgdXyIAHKj9li1rV3xtTe71osIQyo6/gRBd2w==', N'c2811482-2303-4cd2-9690-ee93c8335216', NULL, 0, 0, NULL, 1, 0, N'admin@email.com')

");
        }
        
        public override void Down()
        {
        }
    }
}
