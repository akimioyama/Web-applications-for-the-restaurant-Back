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
    public class SessionsSelects : ISessionsSelects
    {
        public Session AddSession(int tableId, int userId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Table table = db.Tables.FirstOrDefault(t => t.Id == tableId);
                    if (table != null && table.IsFree)
                    {
                        table.IsFree = false;
                        Session session = new Session()
                        {
                            TableId = tableId,
                            UserId = userId,
                            StartDateTime = DateTime.Now,
                            PayableCheck = 0,
                            PaymentState = false
                        };
                        db.Sessions.Add(session);
                        db.SaveChanges();
                        return session;
                    }
                    else return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public Session GetSessionByTableId(int tableId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (!db.Tables.FirstOrDefault(t => t.Id == tableId).IsFree)
                    {

                        Session session = db.Sessions.Where(s => s.TableId == tableId && s.EndDateTime == null).OrderByDescending(s=>s.StartDateTime).Include(s => s.Orders).ThenInclude(o => o.Menu).FirstOrDefault();
                        return session;
                    }
                    else return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public decimal FormPayableCheck(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Session session = db.Sessions.Include(s => s.Orders).FirstOrDefault(s => s.Id == id);
                    if (session != null)
                    {
                        session.PayableCheck = session.Orders.Sum(order=>order.ActualPrice);
                        db.SaveChanges();
                        return session.PayableCheck != null ? (decimal)session.PayableCheck : -1;
                    }
                    else return -1;
                }
            }
            catch
            {
                return -1;
            }
        }
        public bool ChangePaymentState(int id, bool paymentState)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Session session = db.Sessions.FirstOrDefault(s => s.Id == id);
                    if (session != null)
                    {
                        session.PaymentState = paymentState;
                        session.EndDateTime = DateTime.Now;
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
    }
}
