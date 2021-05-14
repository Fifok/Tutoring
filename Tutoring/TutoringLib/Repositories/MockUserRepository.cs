using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Models;

namespace TutoringLib.Repositories
{
    public class MockUserRepository : IRepository<User>
    {
        public void Add(User model)
        {
            throw new NotImplementedException();
        }

        public User GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(User model)
        {
            throw new NotImplementedException();
        }
    }
}
