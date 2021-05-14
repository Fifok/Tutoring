using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringLib.Models;

namespace TutoringLib.Repositories
{
    public class MockUserRepository : IRepository<User>
    {
        private ICollection<User> _users = new List<User>();
        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<User> GetAll()
        {
            return _users.ToList();
        } 
        
        public void Add(User model)
        {
            _users.Add(model);
        }

        public void Remove(User model)
        {
            _users.Remove(model);
        }

        public void Update(User model)
        {
            var oldUser = _users.FirstOrDefault(x => x.Id == model.Id);
            if(oldUser != null)
            {
                _users.Remove(oldUser);
                _users.Add(model);
            }
        }
    }
}
