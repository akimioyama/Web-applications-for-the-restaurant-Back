using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Interfaces
{
    public interface IOrdersSelects
    {
        public int AddOrder(int sessionId, int menuItemId);
        public bool DeleteOrder(int orderId);
        public List<Order> GetOrderBySessionId(int sessionId);
    }
}
