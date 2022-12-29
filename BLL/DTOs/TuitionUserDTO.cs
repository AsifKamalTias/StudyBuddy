using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TuitionUserDTO : TuitionDTO
    {
        public List<UserDTO> Users { get; set;}
        public TuitionUserDTO() 
        {
            Users = new List<UserDTO>();
        }
    }
}
