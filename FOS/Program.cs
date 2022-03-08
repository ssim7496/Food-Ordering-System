using FOS.Data;
using FOS.Data.Authentication;
using FOS.Data.Services;
using FOS.HostedService;
using FOS_API.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o =>
{
    o.AddPolicy("CORSPolicy", b =>
    {
        b.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000");
    });
});

var settings = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(settings);
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Food Ordering System API", Version = "1.0" });
});

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(y =>
{
    y.DocumentTitle = "Food Ordering System";
    y.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API for Food Ordering System");
    y.RoutePrefix = string.Empty;
});
//}

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");
app.UseAuthentication();

#region Authentication Endpoints

app.MapPost("/authenticateCustomer", ([FromBody] Customer customer) =>
{
    string validateMessage = customer.Validate();

    if (string.IsNullOrEmpty(validateMessage))
    {
        WindowsAuthentication authentication = new WindowsAuthentication(customer);

        if (authentication.Authenticate())
        {
            return Results.Ok(true);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    else
    {
        return Results.BadRequest(validateMessage);
    }
}).WithTags("Authentication Endpoints");

app.MapPost("/loginCustomer/", async ([FromBody] Customer customer) =>
{
    bool valid = await CustomerRepository.LoginUser(customer);

    return valid ? Results.Ok(customer) : Results.BadRequest(new Customer());

}).WithTags("Authentication Endpoints");

app.MapPost("/registerCustomer", async (Customer customer) =>
{
    bool added = await CustomerRepository.RegisterCustomerAsync(customer);

    return added ? Results.Ok("Registered successfully") : Results.BadRequest();

}).WithTags("Authentication Endpoints");

#endregion

#region Order Status End Points
app.MapGet("/getAllOrderStatuses", async () => await OrderStatusRepository.GetOrderStatusesAsync())
    .WithTags("Order Status Endpoints");

app.MapGet("/getOrderStatusByID/{ID}", async (int ID) =>
{
    OrderStatus orderStatus = await OrderStatusRepository.GetOrderStatusByIDAsync(ID);

    return orderStatus != null ? Results.Ok(orderStatus) : Results.BadRequest();

}).WithTags("Order Status Endpoints");

app.MapPost("/addOrderStatus", async (OrderStatus orderStatus) =>
{
    bool added = await OrderStatusRepository.AddOrderStatusAsync(orderStatus);

    return added ? Results.Ok("Created successfully") : Results.BadRequest();

}).WithTags("Order Status Endpoints");

app.MapPut("/updateOrderStatus", async (OrderStatus orderStatus) =>
{
    bool updated = await OrderStatusRepository.UpdateOrderStatusAsync(orderStatus);

    return updated ? Results.Ok("Updated successfully") : Results.BadRequest();

}).WithTags("Order Status Endpoints");

app.MapDelete("/deleteOrderStatus/{ID}", async (int ID) =>
{
    bool deleted = await OrderStatusRepository.DeleteOrderStatusAsync(ID);

    return deleted ? Results.Ok("Deleted successfully") : Results.BadRequest();

}).WithTags("Order Status Endpoints");

#endregion

#region Menu Category End Points
app.MapGet("/getAllMenuCategories", async () => await MenuCategoryRepository.GetMenuCategoriesAsync())
    .WithTags("Menu Category Endpoints");

app.MapGet("/getMenuCategoryByID/{ID}", async (int ID) =>
{
    MenuCategory menuCategory = await MenuCategoryRepository.GetMenuCategoryByIDAsync(ID);

    return menuCategory != null ? Results.Ok(menuCategory) : Results.BadRequest();

}).WithTags("Menu Category Endpoints");

app.MapPost("/addMenuCategory", async (MenuCategory menuCategory) =>
{
    bool added = await MenuCategoryRepository.AddMenuCategoryAsync(menuCategory);

    return added ? Results.Ok("Created successfully") : Results.BadRequest();

}).WithTags("Menu Category Endpoints");

app.MapPut("/updateMenuCategory", async (MenuCategory menuCategory) =>
{
    bool updated = await MenuCategoryRepository.UpdateMenuCategoryAsync(menuCategory);

    return updated ? Results.Ok("Updated successfully") : Results.BadRequest();

}).WithTags("Menu Category Endpoints");

app.MapDelete("/deleteMenuCategory/{ID}", async (int ID) =>
{
    bool deleted = await MenuCategoryRepository.DeleteMenuCategoryAsync(ID);

    return deleted ? Results.Ok("Deleted successfully") : Results.BadRequest();

}).WithTags("Menu Category Endpoints");

#endregion

#region Menu Item End Points
app.MapGet("/getAllMenuItems", async () => await MenuItemRepository.GetMenuItemsAsync())
    .WithTags("Menu Item Endpoints");

app.MapGet("/getMenuItemByID/{ID}", async (int ID) =>
{
    MenuItem menuItem = await MenuItemRepository.GetMenuItemByIDAsync(ID);

    return menuItem != null ? Results.Ok(menuItem) : Results.BadRequest();

}).WithTags("Menu Item Endpoints");

app.MapGet("/getMenuItemByCategory/{ID}", async (int ID) =>
{
    List<MenuItem> menuItems = await MenuItemRepository.GetMenuItemsForCategoryAsync(ID);

    return menuItems != null ? Results.Ok(menuItems) : Results.BadRequest();

}).WithTags("Menu Item Endpoints");

app.MapPost("/addMenuItem", async (MenuItem menuItem) =>
{
    bool added = await MenuItemRepository.AddMenuItemAsync(menuItem);

    return added ? Results.Ok("Created successfully") : Results.BadRequest();

}).WithTags("Menu Item Endpoints");

app.MapPut("/updateMenuItem", async (MenuItem menuItem) =>
{
    bool updated = await MenuItemRepository.UpdateMenuItemAsync(menuItem);

    return updated ? Results.Ok("Updated successfully") : Results.BadRequest();

}).WithTags("Menu Item Endpoints");

app.MapDelete("/deleteMenuItem/{ID}", async (int ID) =>
{
    bool deleted = await MenuItemRepository.DeleteMenuItemAsync(ID);

    return deleted ? Results.Ok("Deleted successfully") : Results.BadRequest();

}).WithTags("Menu Item Endpoints");

#endregion

#region Order Item End Points
app.MapGet("/getAllOrderItems", async () => await OrderItemRepository.GetOrderItemsAsync())
    .WithTags("Order Item Endpoints");

app.MapGet("/getOrdersItemsForOrderID/{ID}", async (int ID) => await OrderItemRepository.GetOrdersItemsForOrderID(ID))
    .WithTags("Order Item Endpoints");

app.MapGet("/getOrderItemByID/{ID}", async (int ID) =>
{
    OrderItem OrderItem = await OrderItemRepository.GetOrderItemByIDAsync(ID);

    return OrderItem != null ? Results.Ok(OrderItem) : Results.BadRequest();

}).WithTags("Order Item Endpoints");

app.MapPost("/addOrderItem", async (OrderItem OrderItem) =>
{
    bool added = await OrderItemRepository.AddOrderItemAsync(OrderItem);

    return added ? Results.Ok("Created successfully") : Results.BadRequest();

}).WithTags("Order Item Endpoints");

app.MapPut("/updateOrderItem", async (OrderItem OrderItem) =>
{
    bool updated = await OrderItemRepository.UpdateOrderItemAsync(OrderItem);

    return updated ? Results.Ok("Updated successfully") : Results.BadRequest();

}).WithTags("Order Item Endpoints");

app.MapDelete("/deleteOrderItem/{ID}", async (int ID) =>
{
    bool deleted = await OrderItemRepository.DeleteOrderItemAsync(ID);

    return deleted ? Results.Ok("Deleted successfully") : Results.BadRequest();

}).WithTags("Order Item Endpoints");

#endregion

#region Order End Points
app.MapGet("/getAllOrders", async () => {
    await OrderRepository.GetOrdersAsync();    
}).WithTags("Order Endpoints");

app.MapGet("/getOrderByID/{ID}", async (int ID) =>
{
    Order order = await OrderRepository.GetOrderByIDAsync(ID);

    return order != null ? Results.Ok(order) : Results.BadRequest();

}).WithTags("Order Endpoints");

app.MapGet("/getOrdersForCustomerID/{ID}", async (int ID) => await OrderRepository.GetOrdersForCustomerID(ID))
    .WithTags("Order Endpoints");

app.MapPost("/addOrder", async (Order order) =>
{
    int orderID = await OrderRepository.AddOrderAsync(order);

    if(orderID > 0)
    {
        MailService service = new MailService(settings);
        var message = new MailRequest() { ToEmail = order.Customer.Email, Subject = "FOS Order #" + orderID, Body = "Your order has been ordered and the total price is R" + order .Price};
        await service.SendEmailAsync(message);
        var messageAdmin = new MailRequest() { ToEmail = settings.From, Subject = "Order has been placed - ORDER #" + order.ID, Body = order.Customer.Username + " has placed an order for R" + order.Price };
        await service.SendEmailAsync(messageAdmin);
    }

    return orderID > 0 ? Results.Ok(orderID) : Results.BadRequest();

}).WithTags("Order Endpoints");

app.MapPut("/updateOrder", async (Order order) =>
{
    bool updated = await OrderRepository.UpdateOrderAsync(order);

    return updated ? Results.Ok("Updated successfully") : Results.BadRequest();

}).WithTags("Order Endpoints");

app.MapDelete("/deleteOrder/{ID}", async (int ID) =>
{
    bool deleted = await OrderRepository.DeleteOrderAsync(ID);

    return deleted ? Results.Ok("Deleted successfully") : Results.BadRequest();

}).WithTags("Order Endpoints");

app.MapPut("/prepareOrder", async (Order order) =>
{
    bool prepared = await OrderRepository.PrepareOrderAsync(order);

    if (prepared)
    {
        MailService service = new MailService(settings);
        var message = new MailRequest() { ToEmail = order.Customer.Email, Subject = "FOS Order #" + order.ID, Body = "Your order has been prepared" };
        await service.SendEmailAsync(message);
    }

    return prepared ? Results.Ok("Order Prepared") : Results.BadRequest();

}).WithTags("Order Endpoints");

app.MapPut("/completeOrder", async (Order order) =>
{
    bool completed = await OrderRepository.CompleteOrderAsync(order);

    if (completed)
    {
        MailService service = new MailService(settings);
        var message = new MailRequest() { ToEmail = order.Customer.Email, Subject = "FOS Order #" + order.ID, Body = "Your order has been completed and ready for collection" };
        await service.SendEmailAsync(message);
    }

    return completed ? Results.Ok("Order Completed") : Results.BadRequest();

}).WithTags("Order Endpoints");

#endregion

app.Run();