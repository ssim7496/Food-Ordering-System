using FOS_API.Data;
using Microsoft.EntityFrameworkCore;

namespace FOS.Data.Services
{
    internal static class OrderStatusRepository
    {
        internal async static Task<List<OrderStatus>> GetOrderStatusesAsync()
        {
            using (var db = new FOSDBContext())
            {
                return await db.OrderStatuses.ToListAsync();
            }
        }

        internal async static Task<OrderStatus> GetOrderStatusByIDAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                return await db.OrderStatuses.FirstOrDefaultAsync(x => x.ID == ID);
            }
        }

        internal async static Task<bool> AddOrderStatusAsync(OrderStatus orderStatus)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    await db.OrderStatuses.AddAsync(orderStatus);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateOrderStatusAsync(OrderStatus orderStatus)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    db.OrderStatuses.Update(orderStatus);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteOrderStatusAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    OrderStatus orderStatus = await GetOrderStatusByIDAsync(ID);
                    
                    db.Remove(orderStatus);

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
