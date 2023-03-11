using RestaurantWebApplication.Domain;
using RestaurantWebApplication.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantWebApplication.EntityFramework.Repository.Implementation
{
    public class OrdersSelects : IOrdersSelects
    {
        public int AddOrder(int sessionId, int menuItemId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Order order = new Order()
                    {
                        SessionId = sessionId,
                        MenuId = menuItemId,
                        ActualPrice = db.Menu.FirstOrDefault(m=>m.Id == menuItemId).Price
                    };
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return order.Id;
                }
            }
            catch
            {
                return 0;
            }
        }
        public bool DeleteOrder(int orderId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Order order = db.Orders.FirstOrDefault(o => o.Id == orderId);
                    if (order != null)
                    {
                        db.Orders.Remove(order);
                        db.SaveChanges();
                        return true;
                    }
                    else return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<Order> GetOrderBySessionId(int sessionId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    List<Order> orders = db.Orders.Where(o => o.SessionId == sessionId).Include(o=>o.Menu).ToList();
                    return orders;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
