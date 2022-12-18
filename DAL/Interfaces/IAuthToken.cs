using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuthToken
    {
        bool ExpireToken(string tkey);
        int GetRolePlayer(string tkey); 
    }
}
