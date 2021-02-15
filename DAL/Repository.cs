using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private userDBContext _db = null;
        protected DbSet<T> entities = null;
        public Repository()
        {
            _db = new userDBContext();
            entities = _db.Set<T>();
        }
        public int addUser(user u)
        {
            using (userDBContext db = new userDBContext())
            {
                if (u.name!=null)
                {
                    db.users.Add(u);
                   return db.SaveChanges();
                }
                else
                {
                    return 0;
                }
            }
        }

        public void deleteUser(int id)
        {
            using (userDBContext db = new userDBContext())
            {
                user u = new user();
                u.id = id;
                db.users.Attach(u);
                db.users.Remove(u);
                db.SaveChanges();
            }
        }

        public IEnumerable<user> getAllUser()
        {
            using (userDBContext db = new userDBContext())
            {
                IEnumerable<user> usr = db.users.ToList<user>();
                return usr;
            }
        }

        public user edit(int id)
        {
            using (userDBContext db = new userDBContext())
            {
               user u = db.users.Find(id);
                return u;
            }
        }

        public void update(user u)
        {
            using (userDBContext db = new userDBContext())
            {
                user usr = new user();
                usr = db.users.Find(u.id);
                usr.name = u.name;
                db.SaveChanges();
            }
        }

        public user find(int id)
        {
            using (userDBContext db = new userDBContext())
            {
                user u = db.users.Find(id);
                return u;
            }
        }
    }
}
