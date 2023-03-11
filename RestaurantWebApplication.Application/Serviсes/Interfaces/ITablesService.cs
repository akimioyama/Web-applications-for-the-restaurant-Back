﻿using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Interfaces
{
    public interface ITablesService
    {
        public IEnumerable<TableDTO> GetAllTables();
        public bool ChangeTable(TableChangeDTO table);
    }
}
