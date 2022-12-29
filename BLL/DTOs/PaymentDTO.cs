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
    public class PaymentDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TransactionKey { get; set; }
        [Required]
        public bool IsVerified { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int TuitionId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
