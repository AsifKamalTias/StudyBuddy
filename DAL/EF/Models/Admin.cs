using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]
        [Required]
        public string Username { get; set; }
        [StringLength(50)]
        [Required]
        public string Password { get; set; }
        public virtual List<AdminAuthToken> AdminAuthTokens { get; set; }
        public Admin()
        {
            AdminAuthTokens = new List<AdminAuthToken>();
        }
    }
}
