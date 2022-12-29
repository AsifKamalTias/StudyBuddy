using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
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
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{5,}", ErrorMessage = "Your password must be at least 5 characters long and contain at least 1 letter and 1 number")]
        public string Password { get; set; }
<<<<<<< HEAD
        
=======
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
        [Required]
        public bool IsBlocked { get; set; }
        [Required]
        public bool IsVerified { get; set; }

        [StringLength(10)]
        public string OTP { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
