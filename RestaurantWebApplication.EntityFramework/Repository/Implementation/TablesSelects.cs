using RestaurantWebApplication.Domain;
using RestaurantWebApplication.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Implementation
{
    public class TablesSelects : ITablesSelects
    {
        public List<Table> GetAll()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Tables.ToList();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
