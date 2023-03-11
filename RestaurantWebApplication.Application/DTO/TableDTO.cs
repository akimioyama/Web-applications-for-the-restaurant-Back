using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.DTO
{
    public class TableDTO
    {
        public TableDTO() { }
        public TableDTO(int id, bool isFree, Booking NextBoking, Session session)
        {
            //Если кто-то это читает, то я хочу сказать, что писал это не по своей воле, а потому что фронтедчику было принципиально, чтобы всё было в одном запросе
            Id = id;
            IsFree = isFree;
            DateTime = NextBoking?.DateTime;
            FIO = NextBoking?.FIO;
            if(session!=null)
            Session = new SessionDTO()
            {
                Id = session.Id,
                StartDateTime = session.StartDateTime,
                PayableCheck = session.PayableCheck,
                Orders = session.Orders?.Select(o => new OrderDTO()
                {
                    Id = o.Id,
                    NameMenuItem = o.Menu?.Name,
                    ActualPrice = o.ActualPrice
                })?.ToList()
            };
        }
        public int Id { get; set; }
        public bool IsFree { get; set; }
        public DateTime? DateTime { get; set; }
        public string FIO { get; set; }
        public SessionDTO Session { get; set; }
    }
}
