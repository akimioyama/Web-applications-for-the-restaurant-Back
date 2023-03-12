using RestaurantWebApplication.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Interfaces
{
    public interface IAccountService
    {
        public AccountGetDTO GetJWTToken(AccountLoginDTO accountLoginDTO);
    }
}
