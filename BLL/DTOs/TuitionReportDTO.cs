using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TuitionReportDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Message { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int TuitionId { get; set; }
        [Required]
        public int TutorId { get; set; }
    }
}
