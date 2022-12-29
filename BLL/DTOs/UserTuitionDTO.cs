using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserTuitionDTO : UserDTO
    {
        public List<TuitionDTO> Tuitions { get; set;}
        public UserTuitionDTO() 
        { 
            Tuitions = new List<TuitionDTO>();
        }
    }
}
