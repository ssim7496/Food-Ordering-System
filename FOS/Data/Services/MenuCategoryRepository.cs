using FOS_API.Data;
using Microsoft.EntityFrameworkCore;

namespace FOS.Data.Services
{
    internal static class MenuCategoryRepository
    {
        internal async static Task<List<MenuCategory>> GetMenuCategoriesAsync()
        {
            using (var db = new FOSDBContext())
            {
                return await db.MenuCategories.OrderBy(mc => mc.Order).ToListAsync();
            }
        }

        internal async static Task<MenuCategory> GetMenuCategoryByIDAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                return await db.MenuCategories.FirstOrDefaultAsync(x => x.MenuCategoryId == ID);
            }
        }

        internal async static Task<bool> AddMenuCategoryAsync(MenuCategory menuCategory)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    var list = await db.MenuCategories.OrderByDescending(mc => mc.Order).ToListAsync();
                    double order = list[0].Order +1;
                    menuCategory.Order = order;

                    await db.MenuCategories.AddAsync(menuCategory);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateMenuCategoryAsync(MenuCategory menuCategory)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    db.MenuCategories.Update(menuCategory);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteMenuCategoryAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    MenuCategory menuCategory = await GetMenuCategoryByIDAsync(ID);

                    db.Remove(menuCategory);

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
