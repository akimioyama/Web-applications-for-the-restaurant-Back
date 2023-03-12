using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Interfaces
{
    public interface IUsersSelects
    {
        public User GetUserByLoginAndPassword(string login, string password);
        public List<User> GetAllUsers();
        public int AddUser(User user);
        public bool ChangeUser(User user);
        public bool DeleteUser(int id);
    }
}
