using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TuitionTutorRequest
    {
        public int Id { get; set; }
        [StringLength(500)]
        public string Message { get; set; }
        [Required]
        public bool IsAccepted { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("Tuition")]
        public int TuitionId { get; set; }
        public virtual Tuition Tuition { get; set; }

        [ForeignKey("Tutor")]
        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}
