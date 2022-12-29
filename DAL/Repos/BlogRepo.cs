using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BlogRepo : Repo, IRepo<Blog, int, Blog>
    {
        public Blog Add(Blog obj)
        {
            db.Blogs.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Blogs.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Blog> Get()
        {
            return db.Blogs.ToList();
        }

        public Blog Get(int id)
        {
            return db.Blogs.Find(id);
        }

        public Blog Update(Blog obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
