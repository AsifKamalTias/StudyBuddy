using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITuitionSpecial
    {
        List<Tuition> GetVerified();
        List<Tuition> GetPending();
        List<Tuition> GetUserTuition(int id);
        bool Unverify(int id);
        bool Verify(int id);
        bool Accept (int id);
    }
}
