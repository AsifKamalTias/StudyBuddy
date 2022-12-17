using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuth<RETURN, PARAM1, PARAM2>
    {
        RETURN Authenticate(PARAM1 uniqueIdentity, PARAM2 password);
    }
}
