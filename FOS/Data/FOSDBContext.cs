using FOS.Data;
using Microsoft.EntityFrameworkCore;

namespace FOS_API.Data
{
    internal sealed class FOSDBContext : DbContext
    {
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) =>
                dbContextOptionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=FOSDB;Integrated Security=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<OrderStatus> orderStatuses = new List<OrderStatus>();
            orderStatuses.Add(new OrderStatus() { ID = 1, Description = "Ordered" });
            orderStatuses.Add(new OrderStatus() { ID = 2, Description = "Prepared" });
            orderStatuses.Add(new OrderStatus() { ID = 3, Description = "Complete" });

            modelBuilder.Entity<OrderStatus>()
                .HasData(orderStatuses);

            List<MenuCategory> menuCategories = new List<MenuCategory>();
            menuCategories.Add(new MenuCategory() { MenuCategoryId = 1, Name = "Starters", Order = 1.0 });
            menuCategories.Add(new MenuCategory() { MenuCategoryId = 2, Name = "Salads", Order = 2.0 });
            menuCategories.Add(new MenuCategory() { MenuCategoryId = 3, Name = "Wraps", Order = 3.0 });
            menuCategories.Add(new MenuCategory() { MenuCategoryId = 4, Name = "Burgers", Order = 4.0 });
            menuCategories.Add(new MenuCategory() { MenuCategoryId = 5, Name = "Pasta", Order = 5.0 });
                        
            modelBuilder.Entity<MenuCategory>()
                .Property(x => x.Order)
                .HasPrecision(18, 2);
            modelBuilder.Entity<MenuCategory>()
                .HasData(menuCategories);

            List<MenuItem> menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem() { MenuItemId = 1, MenuCategoryId = 1, Name = "Nachos", Price = 75.0, Order = 1.0, Visible = true, Description = "Nachos guacamole Nachos layered with cheddar cheese, jalapenos, sour cream, fresh salsa and guacamole" });
            menuItems.Add(new MenuItem() { MenuItemId = 2, MenuCategoryId = 1, Name = "Grilled chicken wings", Price = 70.0, Order = 2.0, Visible = true, Description = "Marinated grilled chicken wings prepared in your choice of sauce, per-peri, lemon and herb or barbeque" });
            menuItems.Add(new MenuItem() { MenuItemId = 3, MenuCategoryId = 1, Name = "Chicken Livers Peri-Peri", Price = 58.0, Order = 3.0, Visible = true, Description = "Chicken livers pan seared with chilli, garlic, ginger, napped with a creamy tomato sauce served with bruschetta" });
            menuItems.Add(new MenuItem() { MenuItemId = 4, MenuCategoryId = 2, Name = "Greek Salad", Price = 68.0, Order = 4.0, Visible = true, Description = "Tomato, onion, cucumber, peppers, feta cheese and olives" });
            menuItems.Add(new MenuItem() { MenuItemId = 5, MenuCategoryId = 2, Name = "Avocado and prawn salad", Price = 125.0, Order = 5.0, Visible = true, Description = "Avocado and prawns served with a tantalizing seafood dressing" });
            menuItems.Add(new MenuItem() { MenuItemId = 6, MenuCategoryId = 3, Name = "Beef wrap", Price = 98.0, Order = 6.0, Visible = true, Description = "Beef strips, stir fried vegetables prepared in a peri-peri sauce" });
            menuItems.Add(new MenuItem() { MenuItemId = 7, MenuCategoryId = 3, Name = "Chicken wrap", Price = 96.0, Order = 7.0, Visible = true, Description = "Strips of tender chicken fillet sautéed with fresh peppers, halloumi cheese and sweet and sour sauce" });
            menuItems.Add(new MenuItem() { MenuItemId = 8, MenuCategoryId = 4, Name = "Famous burger", Price = 143.0, Order = 8.0, Visible = true, Description = "Homemade beef patty topped with crispy bacon, tempura onions, avocado guacamole, smoky cheddar, home-made tomato salsa and fresh rocket" });
            menuItems.Add(new MenuItem() { MenuItemId = 9, MenuCategoryId = 4, Name = "Chicken cheese & pineapple", Price = 108.0, Order = 9.0, Visible = true, Description = "Chicken Fillet topped with fresh pineapple and sweet chilli basting" });
            menuItems.Add(new MenuItem() { MenuItemId = 10, MenuCategoryId = 5, Name = "Pasta alfredo", Price = 105.0, Order = 10.0, Visible = true, Description = "Fried mushroom and ham in a creamy garlic sauce" });
            menuItems.Add(new MenuItem() { MenuItemId = 11, MenuCategoryId = 5, Name = "Prawn pasta", Price = 135.0, Order = 11.0, Visible = true, Description = "Grilled prawns finished with a chilli infused creamy tomato sauce" });
            menuItems.Add(new MenuItem() { MenuItemId = 12, MenuCategoryId = 5, Name = "Pesto chicken", Price = 125.0, Order = 12.0, Visible = true, Description = "Char grilled chicken strips pan fried with white wine, garlic mushroom and a creamy pesto sauce" });
                        
            modelBuilder.Entity<MenuItem>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<MenuItem>()
                .HasData(menuItems);

            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<MenuItem>()
                .Navigation(x => x.MenuCategory)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<OrderItem>()
                .Navigation(x => x.Order)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<OrderItem>()
                .Navigation(x => x.MenuItem)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<Order>()
                .Navigation(x => x.OrderStatus)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<Order>()
                .Navigation(x => x.Customer)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            base.OnModelCreating(modelBuilder);
        }
    }
}
