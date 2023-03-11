using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Interfaces
{
    public interface ITablesSelects
    {
        public List<Table> GetAll();
        public bool ChangeTable(Table table);
    }
}
