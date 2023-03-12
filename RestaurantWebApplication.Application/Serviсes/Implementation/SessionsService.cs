using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Application.Serviсes.Interfaces;
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
    public class SessionsService : ISessionsService
    {
        ISessionsSelects sessionsSelects;
        public SessionsService()
        {
            sessionsSelects = new SessionsSelects();
        }
        public SessionDTO AddSession(int tableId, string jwt)
        {
            
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt);
            var tokenS = (JwtSecurityToken)jsonToken;

            int userId = Convert.ToInt32(tokenS.Claims.
                Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).
                Select(claim => claim.Value).FirstOrDefault());
            
            

            Session session = sessionsSelects.AddSession(tableId, userId);
            if (session != null)
            {
                SessionDTO sessionDTO = new SessionDTO()
                {
                    Id = session.Id,
                    StartDateTime = session.StartDateTime,
                    PayableCheck = session.PayableCheck,
                    PaymentState = session.PaymentState,
                    Orders = session.Orders?.Select(o => new OrderDTO()
                    {
                        Id = o.Id,
                        NameMenuItem = o.Menu?.Name,
                        ActualPrice = o.ActualPrice
                    })?.ToList()
                };
                return sessionDTO;
            }
            else return null;
        }
        public SessionDTO GetSessionByTableId(int tableId)
        {
            Session session = sessionsSelects.GetSessionByTableId(tableId);
            SessionDTO sessionDTO = session == null ? null : new SessionDTO()
            {
                Id = session.Id,
                StartDateTime = session.StartDateTime,
                PayableCheck = session.PayableCheck,
                PaymentState = session.PaymentState,
                Orders = session.Orders?.Select(o => new OrderDTO()
                {
                    Id = o.Id,
                    NameMenuItem = o.Menu?.Name,
                    ActualPrice = o.ActualPrice
                })?.ToList()
            };
            return sessionDTO;
        }
        public decimal FormPayableCheck(int id)
        {
            return sessionsSelects.FormPayableCheck(id);
        }
        public bool ChangePaymentState(SessionStateChangeDTO sessionStateChangeDTO)
        {
            return sessionsSelects.ChangePaymentState(sessionStateChangeDTO.Id, sessionStateChangeDTO.PaymentState);
        }
    }
}
