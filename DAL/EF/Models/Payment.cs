using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TransactionKey { get; set; }
        [Required]
        public bool IsVerified { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [ForeignKey("Tuition")]
        public int TuitionId { get; set; }
        public virtual Tuition Tuition { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
