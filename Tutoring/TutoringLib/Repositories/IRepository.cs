using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringLib.Repositories
{
   
    public interface IRepository<T>
    {
        T GetById(int id);
        T GetAll();
        void Add(T model);
        void Remove(T model);
    }
}
