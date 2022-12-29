using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin>, IAuth<Admin, string, string>, IAdminSpecial
    {
        public Admin Add(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Admin Authenticate(string uniqueIdentity, string password)
        {
            var admin = db.Admins.FirstOrDefault(
                    a =>
                    a.Username.Equals(uniqueIdentity) &&
                    a.Password.Equals(password)
                );
            return admin;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Admins.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public Admin Update(Admin obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool UpdatePassword(int id, string password)
        {
            var dbobj = Get(id);
            dbobj.Password = password;
            return db.SaveChanges() > 0;
        }
    }
}
