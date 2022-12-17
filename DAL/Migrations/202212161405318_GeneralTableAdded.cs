namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminAuthTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 50),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Username = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionKey = c.String(nullable: false, maxLength: 50),
                        IsVerified = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        TuitionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tuitions", t => t.TuitionId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.TuitionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tuitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 1000),
                        MonthlyFees = c.Single(nullable: false),
                        Address = c.String(nullable: false, maxLength: 200),
                        Course = c.String(nullable: false, maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TuitionReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 500),
                        Created = c.DateTime(nullable: false),
                        TuitionId = c.Int(nullable: false),
                        TutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tuitions", t => t.TuitionId)
                .ForeignKey("dbo.Tutors", t => t.TutorId)
                .Index(t => t.TuitionId)
                .Index(t => t.TutorId);
            
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 25),
                        PhoneNumber = c.String(maxLength: 15),
                        Description = c.String(maxLength: 500),
                        Address = c.String(maxLength: 100),
                        NID = c.String(maxLength: 15),
                        Photo = c.String(maxLength: 50),
                        EducationLabel = c.String(maxLength: 50),
                        CurrentJob = c.String(maxLength: 50),
                        IsAccepted = c.Boolean(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TuitionTutorRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(maxLength: 500),
                        IsAccepted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        TuitionId = c.Int(nullable: false),
                        TutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tuitions", t => t.TuitionId)
                .ForeignKey("dbo.Tutors", t => t.TutorId)
                .Index(t => t.TuitionId)
                .Index(t => t.TutorId);
            
            CreateTable(
                "dbo.TutorAuthTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 50),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(),
                        TutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tutors", t => t.TutorId)
                .Index(t => t.TutorId);
            
            CreateTable(
                "dbo.TutorRatingFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Single(nullable: false),
                        Feedback = c.String(maxLength: 500),
                        Created = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        TutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tutors", t => t.TutorId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TutorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 50),
                        IsBlocked = c.Boolean(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                        OTP = c.String(maxLength: 10),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAuthTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 50),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 1000),
                        Created = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        TutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tutors", t => t.TutorId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TutorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "TuitionId", "dbo.Tuitions");
            DropForeignKey("dbo.Tuitions", "UserId", "dbo.Users");
            DropForeignKey("dbo.TuitionReports", "TutorId", "dbo.Tutors");
            DropForeignKey("dbo.TutorRatingFeedbacks", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserReports", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserReports", "TutorId", "dbo.Tutors");
            DropForeignKey("dbo.UserAuthTokens", "UserId", "dbo.Users");
            DropForeignKey("dbo.TutorRatingFeedbacks", "TutorId", "dbo.Tutors");
            DropForeignKey("dbo.TutorAuthTokens", "TutorId", "dbo.Tutors");
            DropForeignKey("dbo.TuitionTutorRequests", "TutorId", "dbo.Tutors");
            DropForeignKey("dbo.TuitionTutorRequests", "TuitionId", "dbo.Tuitions");
            DropForeignKey("dbo.TuitionReports", "TuitionId", "dbo.Tuitions");
            DropForeignKey("dbo.AdminAuthTokens", "AdminId", "dbo.Admins");
            DropIndex("dbo.UserReports", new[] { "TutorId" });
            DropIndex("dbo.UserReports", new[] { "UserId" });
            DropIndex("dbo.UserAuthTokens", new[] { "UserId" });
            DropIndex("dbo.TutorRatingFeedbacks", new[] { "TutorId" });
            DropIndex("dbo.TutorRatingFeedbacks", new[] { "UserId" });
            DropIndex("dbo.TutorAuthTokens", new[] { "TutorId" });
            DropIndex("dbo.TuitionTutorRequests", new[] { "TutorId" });
            DropIndex("dbo.TuitionTutorRequests", new[] { "TuitionId" });
            DropIndex("dbo.TuitionReports", new[] { "TutorId" });
            DropIndex("dbo.TuitionReports", new[] { "TuitionId" });
            DropIndex("dbo.Tuitions", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "TuitionId" });
            DropIndex("dbo.AdminAuthTokens", new[] { "AdminId" });
            DropTable("dbo.UserReports");
            DropTable("dbo.UserAuthTokens");
            DropTable("dbo.Users");
            DropTable("dbo.TutorRatingFeedbacks");
            DropTable("dbo.TutorAuthTokens");
            DropTable("dbo.TuitionTutorRequests");
            DropTable("dbo.Tutors");
            DropTable("dbo.TuitionReports");
            DropTable("dbo.Tuitions");
            DropTable("dbo.Payments");
            DropTable("dbo.Admins");
            DropTable("dbo.AdminAuthTokens");
        }
    }
}
