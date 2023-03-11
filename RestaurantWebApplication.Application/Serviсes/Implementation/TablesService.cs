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
    public class TablesService : ITablesService
    {
        ITablesSelects tablesSelects;
        IBookingSelects bookingSelects;
        public TablesService()
        {
            tablesSelects = new TablesSelects();
            bookingSelects = new BookingSelects();
        }
        public IEnumerable<TableDTO> GetAllTables()
        {
            try
            {
                IEnumerable<TableDTO> AllTables = tablesSelects.GetAll().Select(p => new TableDTO() { Id = p.Id, IsFree = p.IsFree, DateTime = bookingSelects.GetFirstActualDateTimeByTableId(p.Id) });
                return AllTables;
            }
            catch
            {
                return null;
            }
        }
    }
}
