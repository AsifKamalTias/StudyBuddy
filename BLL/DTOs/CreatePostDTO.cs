using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float MonthlyFees { get; set; }
        public string Address { get; set; }
        public string Course { get; set; }

    }
}
