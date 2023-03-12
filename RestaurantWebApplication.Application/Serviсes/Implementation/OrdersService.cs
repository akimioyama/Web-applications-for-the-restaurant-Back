using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Application.Serviсes.Interfaces;
using RestaurantWebApplication.EntityFramework.Repository.Implementation;
using RestaurantWebApplication.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Implementation
{
    public class OrdersService : IOrdersService
    {
        IOrdersSelects ordersSelects;
        public OrdersService()
        {
            ordersSelects = new OrdersSelects();
        }
        public int AddOrder(OrderAddDTO orderAddDTO)
        {
            return ordersSelects.AddOrder(orderAddDTO.SessionId, orderAddDTO.MenuItemId);
        }
        public bool DeleteOrder(int orderId)
        {
            return ordersSelects.DeleteOrder(orderId);
        }
        public List<OrderDTO> GetOrderBySessionId(int sessionId)
        {
            List<OrderDTO> result = ordersSelects.GetOrderBySessionId(sessionId)?.Select(o => new OrderDTO()
            {
                Id = o.Id,
                NameMenuItem = o.Menu?.Name,
                ActualPrice = o.ActualPrice
            })?.ToList();
            return result;
        }
    }
}
