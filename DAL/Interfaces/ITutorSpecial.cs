using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITutorSpecial
    {
        bool EditProfile(int id, string name, string password, string phonenumber, string description, string address, string educationlabel, string currentjob);
        bool CheckDuplicateEmail(string email);
        bool Accept(int id);
    }
}
