using Store.EF;
using Store.interfaces;
using System.Drawing.Text;
using Microsoft.EntityFrameworkCore;
using Store.Repository;
using Microsoft.AspNetCore.Builder;
using Store.Migrations;
using Store.Models;
using System.Runtime;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();


builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
builder.Services.AddTransient<IAllOrders,OrdersRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => Store.Models.StoreCart.GetCart(sp));
builder.Services.AddMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    StoreDbContext storeDbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
    DBObjects.GetInitial(storeDbContext);
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Favorite}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "CategoryFilter",
    pattern: "{controller=Cars}/{action}/{categ?}");
app.Run();
