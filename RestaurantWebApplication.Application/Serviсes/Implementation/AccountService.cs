using Microsoft.IdentityModel.Tokens;
using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Application.Serviсes.Interfaces;
using RestaurantWebApplication.Common;
using RestaurantWebApplication.Domain;
using RestaurantWebApplication.EntityFramework.Repository.Implementation;
using RestaurantWebApplication.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Implementation
{
    public class AccountService : IAccountService
    {
        IUsersSelects usersSelects;
        public AccountService()
        {
            usersSelects = new UsersSelects();
        }
        public AccountGetDTO GetJWTToken(AccountLoginDTO accountLoginDTO)
        {
            try
            {
                ClaimsIdentity claimsIdentity;
                User user = usersSelects.GetUserByLoginAndPassword(accountLoginDTO.Login, accountLoginDTO.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                    };
                    claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                }
                else return null;

                var now = DateTime.UtcNow;
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: claimsIdentity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                AccountGetDTO result = new AccountGetDTO
                {
                    JWTToken = encodedJwt,
                    Role = user.Role,
                    FIO = user.FIO
                };
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
