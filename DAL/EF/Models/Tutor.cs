using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Tutor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(25)]
        public string Password { get; set; }
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(15)]
        public string NID { get; set; }
        [StringLength(50)]
        public string Photo { get; set; }
        [StringLength(50)]
        public string EducationLabel { get; set; }
        [StringLength(50)]
        public string CurrentJob { get; set;}
        [Required]
        public bool IsAccepted { get; set; }
        [Required]
        public bool IsBlocked { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public virtual List<UserReport> UserReports { get; set; }
        public virtual List<TutorAuthToken> TutorAuthTokens { get; set; }
        public virtual List<TutorRatingFeedback> TutorRatingFeedbacks { get; set; }
        
        public virtual List<TuitionTutorRequest> TuitionTutorRequests { get; set; }
        public virtual List<TuitionReport> TuitionReports { get; set; }
        public Tutor() 
        {
            TutorAuthTokens = new List<TutorAuthToken>();
            UserReports = new List<UserReport>();
            TutorRatingFeedbacks = new List<TutorRatingFeedback>();
            
            TuitionTutorRequests = new List<TuitionTutorRequest>();
            TuitionReports = new List<TuitionReport>();
        }
    }
}
