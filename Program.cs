using Store.EF;
using Store.interfaces;
using Store.mocks;
using System.Drawing.Text;
using Microsoft.EntityFrameworkCore;
using Store.Repository;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
