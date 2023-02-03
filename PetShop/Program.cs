using Microsoft.EntityFrameworkCore;
using PetShop.DataAccess;
using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CodecampN3Context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#region Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddTransient<IProductRepository, ProductDA>();
//builder.Services.AddTransient<ICategoryRepository, CategoryDA>();
//builder.Services.AddTransient<ICustomerRepository, CustomerDA>();
//builder.Services.AddTransient<IOrderRepository, OrderDA>();
//builder.Services.AddTransient<ICategoryProductRepository, CategoryProductDA>();
//builder.Services.AddTransient<ICustomerOrderRepository, CustomerOrderDA>();
//builder.Services.AddTransient<IOrderDetailRepository, OrderDetailDA>();
#endregion

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
