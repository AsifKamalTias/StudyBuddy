using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Tuition
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public float MonthlyFees { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Course { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        

        public virtual List<TuitionTutorRequest> TuitionTutorRequests { get; set; }
        public virtual List<TuitionReport> TuitionReports { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public Tuition()
        {
            TuitionTutorRequests = new List<TuitionTutorRequest>();
            TuitionReports = new List<TuitionReport>();
            Payments = new List<Payment>();
        }
    }
}
