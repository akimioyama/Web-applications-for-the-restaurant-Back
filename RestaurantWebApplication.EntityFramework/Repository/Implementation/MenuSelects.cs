using RestaurantWebApplication.Domain;
using RestaurantWebApplication.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Implementation
{
    public class MenuSelects : IMenuSelects
    {
        public List<MenuItem> GetAllMenuItems()
        {
            try
            {
                using(ApplicationContext db = new ApplicationContext())
                {
                    return db.Menu.ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public int AddMenuItem(MenuItem menuItem)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    menuItem.Id = 0;
                    db.Menu.Add(menuItem);
                    db.SaveChanges();
                    return menuItem.Id;
                }
            }
            catch
            {
                return 0;
            }
        }
        public bool ChangeMenuItem(MenuItem menuItem)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    MenuItem menuItemMain = db.Menu.FirstOrDefault(m => m.Id == menuItem.Id);
                    if (menuItemMain != null)
                    {
                        menuItemMain.Name = menuItem.Name;
                        menuItemMain.Composition = menuItem.Composition;
                        menuItemMain.PictureName = menuItem.PictureName;
                        menuItemMain.Price = menuItem.Price;

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
        public bool DeleteMenuItem(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    MenuItem menuItemMain = db.Menu.FirstOrDefault(m => m.Id == id);
                    if (menuItemMain != null)
                    {
                        db.Menu.Remove(menuItemMain);

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
