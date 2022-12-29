using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentRepo : Repo, IRepo<Payment, int, Payment>, IPaymentSpecial
    {
        public Payment Add(Payment obj)
        {
            db.Payments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Payments.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Payment> Get()
        {
            return db.Payments.ToList();
        }

        public Payment Get(int id)
        {
            return db.Payments.Find(id);
        }

        public Payment Update(Payment obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public List<Payment> GetPendingPayments()
        {
            return db.Payments.Where(t => t.IsVerified == false).ToList();
        }

        public bool Verify(int id)
        {
            var payment = Get(id);
            payment.IsVerified = true;
            return db.SaveChanges() > 0;
        }

        public int GetTuitionId(int id)
        {
            var payment = Get(id);
            return payment.TuitionId;
        }
    }
}
