using RestaurantWebApplication.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Interfaces
{
    public interface IUsersService
    {
        public  List<UserDTO> GetAllUsers();
        public  int AddUser(UserAddDTO user);
        public  bool ChangeUser(UserDTO user);
        public  bool DeleteUser(int id);
    }
}
