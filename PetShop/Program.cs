using Microsoft.EntityFrameworkCore;
using PetShop.DataAccess;
using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;
using PetShop.Service.BannerImage.ViewModel;
using PetShop.Service.Categories;
using PetShop.Service.CauHinhs;
using PetShop.Service.Products;

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
builder.Services.AddTransient<ProductService>();
//builder.Services.AddTransient<ICategoryRepository, CategoryDA>();
//builder.Services.AddTransient<ICustomerRepository, CustomerDA>();
//builder.Services.AddTransient<IOrderRepository, OrderDA>();
//builder.Services.AddTransient<ICategoryProductRepository, CategoryProductDA>();
//builder.Services.AddTransient<ICustomerOrderRepository, CustomerOrderDA>();
//builder.Services.AddTransient<IOrderDetailRepository, OrderDetailDA>();
#endregion

#region Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddTransient<IProductRepository, ProductDA>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<ICategoryRepository, CategoryDA>();
builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<ICauHinhRepository, CauHinhDA>();
builder.Services.AddTransient<CauHinhService>();
builder.Services.AddTransient<IBannerImageRepository, BannerImageDA>();
builder.Services.AddTransient<BannerImageService>();
//builder.Services.AddTransient<ICustomerRepository, CustomerDA>();
//builder.Services.AddTransient<IOrderRepository, OrderDA>();
//builder.Services.AddTransient<ICategoryProductRepository, CategoryProductDA>();
//builder.Services.AddTransient<ICustomerOrderRepository, CustomerOrderDA>();
//builder.Services.AddTransient<IOrderDetailRepository, OrderDetailDA>();
#endregion

builder.Services.AddControllers();
builder.Services.AddSession();

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
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
