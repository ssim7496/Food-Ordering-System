using FOS_API.Data;
using Microsoft.EntityFrameworkCore;
namespace FOS.Data.Services
{
    internal static class CustomerRepository
    {
        internal async static Task<bool> LoginUser(Customer customer)
        {
            using (var db = new FOSDBContext())
            {
                var customers = await db.Customers.FirstOrDefaultAsync(x => x.Username == customer.Username &&
                        x.Domain == customer.Domain && x.Password == customer.Password);

                if (customers == null)
                {
                    return false;
                }

                customer.ID = customers.ID;
                return true;
            }
        }

        internal async static Task<bool> RegisterCustomerAsync(Customer customer)
        {
            using (var db = new FOSDBContext())
            {
                try
                {
                    var customers = await db.Customers.FirstOrDefaultAsync(x => x.Username == customer.Username &&
                        x.Domain == customer.Domain && x.Password == customer.Password);

                    if (customers != null)
                    {
                        return false;
                    }
                    else
                    {
                        await db.Customers.AddAsync(customer);
                        return await db.SaveChangesAsync() >= 1;
                    }                    
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}

