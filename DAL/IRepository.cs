using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        int addUser(user u);
        void deleteUser(int id);
        user find(int id);
        void update(user u); 
        IEnumerable<user> getAllUser();
    }
}
