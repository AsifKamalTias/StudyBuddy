using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TutorRatingFeedback
    {
        public int Id { get; set; }
        [Required]
        public float Rate { get; set; }
        [StringLength(500)]
        public string Feedback { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}
