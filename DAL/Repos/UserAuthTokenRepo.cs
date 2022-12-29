using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserAuthTokenRepo : Repo, IRepo<UserAuthToken, string, UserAuthToken>, IAuthToken
    {
        public UserAuthToken Add(UserAuthToken obj)
        {
            db.UserAuthTokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var dbtk = Get(id);
            db.UserAuthTokens.Remove(dbtk);
            return db.SaveChanges() > 0;
        }

        public List<UserAuthToken> Get()
        {
            return db.UserAuthTokens.ToList();
        }

        public UserAuthToken Get(string id)
        {
            return db.UserAuthTokens.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public UserAuthToken Update(UserAuthToken obj)
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
        public int GetRolePlayer(string tkey)
        {
            var token = Get(tkey);
            return token.UserId;
        }
    }
}
