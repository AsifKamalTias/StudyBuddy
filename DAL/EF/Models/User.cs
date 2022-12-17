using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        public bool IsBlocked { get; set; }
        [Required]
        public bool IsVerified { get; set; }

        [StringLength(10)]
        public string OTP { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public virtual List<UserAuthToken> UserAuthTokens { get; set; }
        public virtual List<UserReport> UserReports { get; set; }
        public virtual List<TutorRatingFeedback> TutorRatingFeedbacks { get; set; }
        public virtual List<Tuition> Tuitions { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public User()
        {
            UserAuthTokens = new List<UserAuthToken>();
            UserReports = new List<UserReport>();
            TutorRatingFeedbacks = new List<TutorRatingFeedback>();
            Tuitions = new List<Tuition>();
            Payments = new List<Payment>();
        }
    }
}
