using RestaurantWebApplication.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Interfaces
{
    public interface ISessionsService
    {
        public SessionDTO AddSession(int tableId, string jwt);
        public SessionDTO GetSessionByTableId(int tableId);
        public decimal FormPayableCheck(int id);
        public bool ChangePaymentState(SessionStateChangeDTO sessionStateChangeDTO);
    }
}
