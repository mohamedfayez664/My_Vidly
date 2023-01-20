namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2a98bfa3-1483-4624-85a6-f11fd8c50d56', N'admin@vidly.com', 0, N'AHozNxeKiniizmdi93Nj5wWb3jq0Fxdfar7D0NAiuA3TJ+KUI/vDn39Kh2Dr89atNg==', N'dcae6147-06a1-466b-9c67-60d9384db6d3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7ecd852f-9694-4ad9-9891-6c2872604c3f', N'guest@Vidly.com', 0, N'AF6U7s6wAxabNtkd0f+/Lqg8MFnA6EB1mDJZDGWSb2wkAD4xwD1A94geVUoTmwXzWQ==', N'6f6ecb6b-4528-4f6e-9e1b-424e5ed8bcdf', NULL, 0, 0, NULL, 1, 0, N'guest@Vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2255bfbe-9604-4848-9a94-354d5692e3ca', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2a98bfa3-1483-4624-85a6-f11fd8c50d56', N'2255bfbe-9604-4848-9a94-354d5692e3ca')

  
               ");
        }
        
        public override void Down()
        {
        }
    }
}
