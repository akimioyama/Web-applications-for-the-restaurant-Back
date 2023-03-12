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
        public List<User> GetAllUsers()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Users.ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public int AddUser(User user)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    user.Id = 0;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return user.Id;
                }
            }
            catch
            {
                return 0;
            }
        }
        public bool ChangeUser(User user)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    User userMain = db.Users.FirstOrDefault(u => u.Id == user.Id);
                    if (userMain != null)
                    {
                        userMain.FIO = user.FIO;
                        userMain.Role = user.Role;
                        userMain.Login = user.Login;
                        userMain.Password = user.Password;

                        db.SaveChanges();
                        return true;
                    }
                    else return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    User userMain = db.Users.FirstOrDefault(u => u.Id == id);
                    if (userMain != null)
                    {
                        db.Remove(userMain);
                        db.SaveChanges();
                        return true;
                    }
                    else return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
