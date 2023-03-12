using RestaurantWebApplication.Domain;
using RestaurantWebApplication.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Implementation
{
    public class UsersSelects : IUsersSelects
    {
        public User GetUserByLoginAndPassword(string login, string password)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
