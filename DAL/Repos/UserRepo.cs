using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>, IAuth<User, string, string>, IUserSpecial
    {
        public User Add(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public User Authenticate(string uniqueIdentity, string password)
        {
            var User = db.Users.FirstOrDefault(
                    a =>
                    a.Email.Equals(uniqueIdentity) &&
                    a.Password.Equals(password) && a.IsVerified == true && a.IsBlocked== false
                );
            return User;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Users.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool CheckOTP(string email, string otp)
        {
            var dbobj = db.Users.FirstOrDefault(
                u => u.Email.Equals(email) && u.OTP.Equals(otp)
                );
            if(dbobj == null )
            {
                return false;
            }
            else
            {
                dbobj.IsVerified= true;
                dbobj.OTP = null;
                db.SaveChanges();
                return true;
            }
            
        }

        public bool EditProfile(int id, string name, string password)
        {
            var user = Get(id);
            user.Name = name;
            user.Password = password;
            return db.SaveChanges() > 0;
        }

        public bool FindUserByEmail(string email)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == email);
                if(user==null) return false;
            return true;
        }
    }
}
