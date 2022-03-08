using FOS_API.Data;
using Microsoft.EntityFrameworkCore;

namespace FOS.Data.Services
{
    internal static class OrderItemRepository
    {
        internal async static Task<List<OrderItem>> GetOrderItemsAsync()
        {
            using (var db = new FOSDBContext())
            {
                return await db.OrderItems.ToListAsync();
            }
        }

        internal async static Task<OrderItem> GetOrderItemByIDAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                return await db.OrderItems.FirstOrDefaultAsync(x => x.ID == ID);
            }
        }

        internal async static Task<List<OrderItem>> GetOrdersItemsForOrderID(int ID)
        {
            using (var db = new FOSDBContext())
            {
                return await db.OrderItems
                            .Include(x => x.Order)
                            .Include(x => x.MenuItem)
                            .Where(x => x.OrderID == ID)
                            .OrderBy(x => x.MenuItem.Name)
                            .ToListAsync();
            }
        }

        internal async static Task<bool> AddOrderItemAsync(OrderItem orderItem)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    await db.OrderItems.AddAsync(orderItem);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateOrderItemAsync(OrderItem orderItem)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    db.OrderItems.Update(orderItem);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteOrderItemAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    OrderItem orderItem = await GetOrderItemByIDAsync(ID);

                    db.Remove(orderItem);

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

