using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITuitionTutorRequestSpecial
    {
        List<TuitionTutorRequest> GetTuitionRequestsByTuition(int id);
        bool Accept(int id);
        int GetTuitionId(int id);

        List<TuitionTutorRequest> GetTutorsAppliedTuitions(int id);
    }
}
