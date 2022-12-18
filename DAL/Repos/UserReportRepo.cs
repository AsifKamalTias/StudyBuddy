using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserReportRepo : Repo, IRepo<UserReport, int, UserReport>
    {
        public UserReport Add(UserReport obj)
        {
            db.UserReports.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.UserReports.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<UserReport> Get()
        {
            return db.UserReports.ToList();
        }

        public UserReport Get(int id)
        {
            return db.UserReports.Find(id);
        }

        public UserReport Update(UserReport obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
