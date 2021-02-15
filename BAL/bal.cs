using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class bal
    {
        private static IRepository<user> repo = new Repository<user>();
         
        public int newUser(user u)
        {
           int i= repo.addUser(u);
            return i;
        }

        public IEnumerable<user> getAll(){
            IEnumerable<user> u = repo.getAllUser();
            return u;
        }
        
        public void delUser(int id)
        {
            repo.deleteUser(id);
        }   
        
        public user editUser(int id) 
        {
            user u = repo.find(id);
            return u;
        }

        public void updateUser(user u)
        {
             repo.update(u);
        }    
    }
}
