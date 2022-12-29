using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserAuthTokenDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TKey { get; set; }
        [Required]
        public System.DateTime CreationTime { get; set; }
        public Nullable<System.DateTime> ExpirationTime { get; set; }
<<<<<<< HEAD
        [Required]
=======
        [ForeignKey("User")]
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
        public int UserId { get; set; }
    }
}
