using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TuitionRepo : Repo, IRepo<Tuition, int, Tuition>, ITuitionSpecial
    {
        public Tuition Add(Tuition obj)
        {
            db.Tuitions.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Tuitions.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Tuition> Get()
        {
            return db.Tuitions.ToList();
        }

        public Tuition Get(int id)
        {
            return db.Tuitions.Find(id);
        }

        public Tuition Update(Tuition obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public List<Tuition> GetVerified()
        {
            return db.Tuitions.Where(t=> t.Status == "verified").ToList();
        }

        public List<Tuition> GetPending()
        {
            return db.Tuitions.Where(t => t.Status == "pending").ToList();
        }

        public bool Unverify(int id)
        {
            var tuition = Get(id);
            tuition.Status = "pending";
            return db.SaveChanges() > 0;
        }

        public bool Verify(int id)
        {
            var tuition = Get(id);
            tuition.Status = "verified";
            return db.SaveChanges() > 0;
        }

        public List<Tuition> GetUserTuition(int id)
        {
            return db.Tuitions.Where(t => t.UserId == id).ToList();
        }

        public bool Accept(int id)
        {
            var tuition = Get(id);
            tuition.Status = "accepted";
            return db.SaveChanges() > 0;
        }
    }
}
