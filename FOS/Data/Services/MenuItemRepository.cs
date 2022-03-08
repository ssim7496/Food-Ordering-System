using FOS.HostedService;
using FOS_API.Data;
using Microsoft.EntityFrameworkCore;

namespace FOS.Data.Services
{
    internal static class MenuItemRepository
    {
        internal async static Task<List<MenuItem>> GetMenuItemsAsync()
        {
            using (var db = new FOSDBContext())
            {   
                return await db.MenuItems.Include(x => x.MenuCategory)
                    .OrderBy(mc => mc.MenuCategoryId)
                    .OrderBy(mc => mc.Order).ToListAsync();
            }
        }

        internal async static Task<MenuItem> GetMenuItemByIDAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                return await db.MenuItems.FirstOrDefaultAsync(x => x.MenuItemId == ID);
            }
        }

        internal async static Task<List<MenuItem>> GetMenuItemsForCategoryAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                return await db.MenuItems.Where(mc => mc.MenuCategoryId == ID)
                    .OrderBy(mc => mc.Order).ToListAsync();
            }
        }

        internal async static Task<bool> AddMenuItemAsync(MenuItem menuItem)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    var list = await db.MenuItems.OrderByDescending(mi => mi.Order).ToListAsync();
                    double order = list[0].Order + 1;
                    menuItem.Order = order;
                    menuItem.Visible = true;

                    await db.MenuItems.AddAsync(menuItem);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateMenuItemAsync(MenuItem menuItem)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    db.MenuItems.Update(menuItem);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteMenuItemAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    MenuItem menuItem = await GetMenuItemByIDAsync(ID);

                    db.Remove(menuItem);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
