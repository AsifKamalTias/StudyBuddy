using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class StudyBuddyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminAuthToken> AdminAuthTokens { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Tuition> Tuitions { get; set; }
        public DbSet<TuitionReport> TuitionReports { get; set; }
        public DbSet<TuitionTutorRequest> TuitionTutorRequests { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<TutorAuthToken> TutorAuthTokens { get; set; }
        public DbSet<TutorRatingFeedback> TutorRatingFeedbacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAuthToken> UserAuthTokens { get; set; }
        public DbSet<UserReport> UserReports { get; set; }

    }
}
