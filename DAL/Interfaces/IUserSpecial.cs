using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserSpecial
    {
        bool CheckOTP(string email, string otp);
        bool EditProfile (int id, string name, string password);

        bool FindUserByEmail(string email);
    }
}
