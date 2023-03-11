using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-FPR118VN\SQLEXPRESS;
                                        Initial Catalog=RestaurantBD;Integrated Security=True;
                                        Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;
                                        Application Intent=ReadWrite;Multi Subnet Failover=False");
            //optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-FPR118VN\SQLEXPRESS;
            //                            Initial Catalog=RestaurantBD;Integrated Security=True;
            //                            Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;
            //                            Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
