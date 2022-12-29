using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TutorRepo : Repo, IRepo<Tutor, int, Tutor>, IAuth<Tutor, string, string>, ITutorSpecial
    {
        public Tutor Add(Tutor obj)
        {
            db.Tutors.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }



        public Tutor Authenticate(string uniqueIdentity, string password)
        {
            var Tutor = db.Tutors.FirstOrDefault(
                    a =>
                    a.Email.Equals(uniqueIdentity) &&
                    a.Password.Equals(password) && a.IsBlocked == false
                );
            return Tutor;
        }



        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Tutors.Remove(dbobj);
            return db.SaveChanges() > 0;
        }



        public List<Tutor> Get()
        {
            return db.Tutors.ToList();
        }



        public Tutor Get(int id)
        {
            return db.Tutors.Find(id);
        }



        public Tutor Update(Tutor obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }



        //change
        public bool EditProfile(int id, string name, string password, string phonenumber, string description, string address, string educationlabel, string currentjob)
        {
            var tutor = Get(id);
            tutor.Name = name;
            tutor.Password = password;
            tutor.PhoneNumber = phonenumber;
            tutor.Description = description;
            tutor.Address = address;
            tutor.EducationLabel = educationlabel;
            tutor.CurrentJob = currentjob;

            return db.SaveChanges() > 0;
        }



        public bool CheckDuplicateEmail(string email)
        {
            var tutor = db.Tutors.FirstOrDefault(x => x.Email == email);
            if (tutor == null) return false;
            return true;
        }

        public bool Accept(int id)
        {
            var tutor = Get(id);
            tutor.IsAccepted = true;
            return db.SaveChanges() > 0;

        }
    }
}
