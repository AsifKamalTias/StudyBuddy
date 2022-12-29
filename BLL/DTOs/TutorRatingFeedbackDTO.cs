using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TutorRatingFeedbackDTO
    {
        public int Id { get; set; }
        [Required]
        public float Rate { get; set; }
        [StringLength(500)]
        public string Feedback { get; set; }
        [Required]
        public DateTime Created { get; set; }
<<<<<<< HEAD

        [Required]
        public int UserId { get; set; }
        [Required]
=======
        public int UserId { get; set; }
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
        public int TutorId { get; set; }
    }
}
