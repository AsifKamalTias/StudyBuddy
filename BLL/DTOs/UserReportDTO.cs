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
<<<<<<< HEAD
     public class UserReportDTO
     {
=======
    public class UserReportDTO
    {
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
        public int Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string Message { get; set; }
        [Required]
        public DateTime Created { get; set; }
<<<<<<< HEAD
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TutorId { get; set; }
     }
=======
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
}
