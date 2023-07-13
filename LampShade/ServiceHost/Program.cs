using _01_LampshadeQuery.Contracts.Slide;
using _01_LampshadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using _01_LampshadeQuery.Contracts.ProductCategory;
using DiscountManagement.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryMangement.Infrastructure.EFCore;
using InventoryMangement.Infrastructure.EFCore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddTransient<IProductApplication, ProductApplication>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
builder.Services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
builder.Services.AddTransient<ISlideApplication, SlideApplication>();
builder.Services.AddTransient<ISlideRepository, SlideRepository>();


builder.Services.AddTransient<ISlideQuery, SlideQuery>();
builder.Services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();


builder.Services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
builder.Services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

builder.Services.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();
builder.Services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();

builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();
builder.Services.AddTransient<IInventoryApplication, InventoryApplication>();






builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));

builder.Services.AddDbContext<DiscountContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));

builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapDefaultControllerRoute();
});
app.MapRazorPages();

app.Run();
