using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TuitionDTO
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
        [Required]
        public int UserId { get; set; }
    }
}
