using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TuitionTutorRequestRepo : Repo, IRepo<TuitionTutorRequest, int, TuitionTutorRequest>, ITuitionTutorRequestSpecial
    {
        public TuitionTutorRequest Add(TuitionTutorRequest obj)
        {
            db.TuitionTutorRequests.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.TuitionTutorRequests.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<TuitionTutorRequest> Get()
        {
            return db.TuitionTutorRequests.ToList();
        }

        public TuitionTutorRequest Get(int id)
        {
            return db.TuitionTutorRequests.Find(id);
        }

        public List<TuitionTutorRequest> GetTuitionRequestsByTuition(int id)
        {
            return db.TuitionTutorRequests.Where(t => t.TuitionId == id).ToList();
        }

        public TuitionTutorRequest Update(TuitionTutorRequest obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Accept(int id)
        {
            var dbobj = Get(id);
            dbobj.IsAccepted = true;
            return db.SaveChanges() > 0;
        }

        public int GetTuitionId(int id)
        {
            var dbobj = Get(id);
            return dbobj.TuitionId;
        }

        public List<TuitionTutorRequest> GetTutorsAppliedTuitions(int id)
        {
            return db.TuitionTutorRequests.Where(t => t.TutorId == id).ToList();
        }
    }
}
