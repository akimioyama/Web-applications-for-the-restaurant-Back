using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Application.Serviсes.Interfaces;
using RestaurantWebApplication.Domain;
using RestaurantWebApplication.EntityFramework.Repository.Implementation;
using RestaurantWebApplication.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Implementation
{
    public class UsersService : IUsersService
    {
        IUsersSelects usersSelects;
        public UsersService()
        {
            usersSelects = new UsersSelects();
        }
        public List<UserDTO> GetAllUsers()
        {
            return usersSelects.GetAllUsers().Select(u => new UserDTO() { Id = u.Id, FIO = u.FIO, Login = u.Login, Password = u.Password, Role = u.Role } ).ToList();
        }
        public int AddUser(UserAddDTO user)
        {
            return usersSelects.AddUser(new User() { FIO = user.FIO, Login = user.Login, Password = user.Password, Role = user.Role });
        }
        public bool ChangeUser(UserDTO user)
        {
            return usersSelects.ChangeUser(new User() { Id = user.Id, FIO = user.FIO, Login = user.Login, Password = user.Password, Role = user.Role });
        }
        public bool DeleteUser(int id)
        {
            return usersSelects.DeleteUser(id);
        }
    }
}
