using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TutorAuthTokenRepo : Repo, IRepo<TutorAuthToken, string, TutorAuthToken>, IAuthToken
    {
        public TutorAuthToken Add(TutorAuthToken obj)
        {
            db.TutorAuthTokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var dbtk = Get(id);
            db.TutorAuthTokens.Remove(dbtk);
            return db.SaveChanges() > 0;
        }

        public List<TutorAuthToken> Get()
        {
            return db.TutorAuthTokens.ToList();
        }

        public TutorAuthToken Get(string id)
        {
            return db.TutorAuthTokens.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public TutorAuthToken Update(TutorAuthToken obj)
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
            return token.TutorId;
        }
    }
}
