using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TuitionReportRepo : Repo, IRepo<TuitionReport, int, TuitionReport>
    {
        public TuitionReport Add(TuitionReport obj)
        {
            db.TuitionReports.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.TuitionReports.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<TuitionReport> Get()
        {
            return db.TuitionReports.ToList();
        }

        public TuitionReport Get(int id)
        {
            return db.TuitionReports.Find(id);
        }

        public TuitionReport Update(TuitionReport obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
