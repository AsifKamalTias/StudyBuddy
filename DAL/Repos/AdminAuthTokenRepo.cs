using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminAuthTokenRepo : Repo, IRepo<AdminAuthToken, string, AdminAuthToken>, IAuthExpire
    {
        public AdminAuthToken Add(AdminAuthToken obj)
        {
            db.AdminAuthTokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var dbtk = Get(id);
            db.AdminAuthTokens.Remove(dbtk);
            return db.SaveChanges() > 0;
        }

        public List<AdminAuthToken> Get()
        {
            return db.AdminAuthTokens.ToList();
        }

        public AdminAuthToken Get(string id)
        {
            return db.AdminAuthTokens.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public AdminAuthToken Update(AdminAuthToken obj)
        {
            var dbobj = Get(obj.TKey);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public bool ExpireToken(string tkey)
        {
            var token = Get(tkey);
            if (token != null)
            {
                token.ExpirationTime = DateTime.Now;
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
