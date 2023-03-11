using RestaurantWebApplication.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Interfaces
{
    public interface IOrdersService
    {
        public int AddOrder(int sessionId, int menuItemId);
        public bool DeleteOrder(int orderId);
        public List<OrderDTO> GetOrderBySessionId(int sessionId);
    }
}
