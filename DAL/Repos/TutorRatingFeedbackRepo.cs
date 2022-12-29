using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TutorRatingFeedbackRepo : Repo, IRepo<TutorRatingFeedback, int, TutorRatingFeedback>
    {
<<<<<<< HEAD
=======

>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
        public TutorRatingFeedback Add(TutorRatingFeedback obj)
        {
            db.TutorRatingFeedbacks.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.TutorRatingFeedbacks.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<TutorRatingFeedback> Get()
        {
            return db.TutorRatingFeedbacks.ToList();
        }

        public TutorRatingFeedback Get(int id)
        {
            return db.TutorRatingFeedbacks.Find(id);
        }

        public TutorRatingFeedback Update(TutorRatingFeedback obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
