namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'221af7e7-3f27-4301-beba-4e55639edd90', N'guest@vidly.com', 0, N'AGrFTvo6rllZP2FxfSaWCTgLCH/UibZR4mcJbNeyfWYZxNwPqkxi6MnzKIDKHmPThQ==', N'948d4d78-a8f8-4e66-9767-f231323d878e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fe1f9ac1-62e0-4df4-b503-4833a27e8adc', N'admin@vidly.com', 0, N'AJQFoqQFZjMj1IR39tBDaHBVwWBy2J6zPEeEDqq0tu5s3wa42YlbzvIDYp6UtR2EpQ==', N'aa907a38-300d-4864-a2cc-13ecae4e2aa9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'25b01cfd-8e6c-4156-a210-bb5a56ec85d4', N'CanManageMovies')

                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fe1f9ac1-62e0-4df4-b503-4833a27e8adc', N'25b01cfd-8e6c-4156-a210-bb5a56ec85d4')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
