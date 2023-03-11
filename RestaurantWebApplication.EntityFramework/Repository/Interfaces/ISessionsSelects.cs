using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Interfaces
{
    public interface ISessionsSelects
    {
        public Session AddSession(int tableId, int userId);
        public Session GetSessionByTableId(int tableId);
        public decimal FormPayableCheck(int id);
        public bool ChangePaymentState(int id, bool paymentState);
    }
}
