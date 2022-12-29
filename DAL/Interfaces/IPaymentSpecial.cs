using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPaymentSpecial
    {
        List<Payment> GetPendingPayments();
        bool Verify(int id);

        int GetTuitionId(int id);
    }
}
