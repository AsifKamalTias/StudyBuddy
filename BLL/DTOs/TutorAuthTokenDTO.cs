using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TutorAuthTokenDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TKey { get; set; }
        [Required]
        public System.DateTime CreationTime { get; set; }
        public Nullable<System.DateTime> ExpirationTime { get; set; }
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }
    }
}
