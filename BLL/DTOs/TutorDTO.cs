using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TutorDTO
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
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{5,}", ErrorMessage = "Your password must be at least 5 characters long and contain at least 1 letter and 1 number")]
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
        public string CurrentJob { get; set; }
        [Required]
        public bool IsAccepted { get; set; }
        [Required]
        public bool IsBlocked { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
