using FOS.HostedService;
using FOS_API.Data;
using Microsoft.EntityFrameworkCore;

namespace FOS.Data.Services
{
    internal static class OrderRepository
    {
        internal async static Task<List<Order>> GetOrdersAsync()
        {            
            using (var db = new FOSDBContext())
            {
                return await db.Orders
                    .Include(x => x.OrderStatus)
                    .Include(x => x.Customer)
                    .OrderByDescending(x => x.DateOrdered)
                    .ToListAsync();
            }
        }

        internal async static Task<Order> GetOrderByIDAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                return await db.Orders.FirstOrDefaultAsync(x => x.ID == ID);
            }
        }

        internal async static Task<List<Order>> GetOrdersForCustomerID(int ID)
        {
            using (var db = new FOSDBContext())
            {
                return await db.Orders
                    .Include(x => x.OrderStatus)
                    .Where(x => x.CustomerID == ID)
                    .OrderByDescending(x => x.DateOrdered).ToListAsync();
            }
        }

        internal async static Task<int> AddOrderAsync(Order order)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    order.OrderStatusID = 1; //ordered
                    order.DateOrdered = DateTime.Now;                    
                    await db.Orders.AddAsync(order);
                    await db.SaveChangesAsync();

                    return order.ID;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        internal async static Task<bool> UpdateOrderAsync(Order order)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    db.Orders.Update(order);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> PrepareOrderAsync(Order order)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    order.OrderStatusID = 2;
                    order.OrderStatus = await db.OrderStatuses.FirstOrDefaultAsync(x => x.ID == 2);
                    order.DatePrepared = DateTime.Now;                    
                    db.Orders.Update(order);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> CompleteOrderAsync(Order order)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    order.OrderStatusID = 3;
                    order.OrderStatus = await db.OrderStatuses.FirstOrDefaultAsync(x => x.ID == 3);
                    order.DateCompleted = DateTime.Now;
                    db.Orders.Update(order);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteOrderAsync(int ID)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    Order order = await GetOrderByIDAsync(ID);

                    db.Remove(order);

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

