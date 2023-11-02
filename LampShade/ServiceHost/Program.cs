using _0_Framework.Application;
using _0_Framework.Infrastructure;
using _01_LampshadeQuery.Contracts.Product;
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
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountMangement.Infrastructure.EFCore.Repository;
using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EFCore.Repository;
using CommentManagement.Application;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using CommnetManagement.Infrastructure.EFCore.Repository;
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
using ServiceHost;
using BlogManagement.Infrastructure.EFCore;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using AccountMangement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using _0_Framework.Application.ZarinPal;
using _01_LampshadeQuery.Contracts.Article;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using InventoryManagement.Infrastructure.Configuration.Permissions;
using ShopManagement.Configuration.Permissions;
using _01_LampshadeQuery.Contracts;
using InventoryManagement.Presentation.Api;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;
using ShopManagement.Infrastructure.AccountAcl;
using ShopManagement.Infrastructure.InventoryAcl;
using ShopManagement.Presentation.Api;
using _01_LampshadeQuery.Contracts.Inventory;

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
builder.Services.AddTransient<IInventoryQuery, InventoryQuery>();


builder.Services.AddTransient<IProductQuery, ProductQuery>();
builder.Services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();


builder.Services.AddTransient<IFileUploader, FileUploader>();

builder.Services.AddTransient<ICommentApplication, CommentApplication>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();


builder.Services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
builder.Services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
builder.Services.AddTransient<IArticleApplication, ArticleApplication>();

builder.Services.AddTransient<IAccountApplication, AccountApplication>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IRoleApplication, RoleApplication>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();


builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();

builder.Services.AddTransient<IArticleQuery, ArticleQuery>();
builder.Services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

builder.Services.AddTransient<IPermissionExposer, ShopPermissionExposer>();
builder.Services.AddTransient<IPermissionExposer, InventoryPermissionExposer>();

builder.Services.AddTransient<ICartCalculatorService, CartCalculatorService>();


builder.Services.AddTransient<IOrderApplication, OrderApplication>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<IZarinPalFactory, ZarinPalFactory>();

builder.Services.AddSingleton<ICartService, CartService>();

builder.Services.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();
builder.Services.AddTransient<IShopAccountAcl, ShopAccountAcl>();



builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Account");
        o.LogoutPath = new PathString("/Account");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea",
        builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ContentUploader }));

    options.AddPolicy("Shop",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));

    options.AddPolicy("Discount",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));

    options.AddPolicy("Account",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));
});

builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
    builder
        .WithOrigins("https://localhost:7069")
        .AllowAnyHeader()
        .AllowAnyMethod()));

builder.Services.AddRazorPages()
    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
    })
    .AddApplicationPart(typeof(ProductController).Assembly)
    .AddApplicationPart(typeof(InventoryController).Assembly)
    .AddNewtonsoftJson();




builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));

builder.Services.AddDbContext<DiscountContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));

builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));

builder.Services.AddDbContext<AccountContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));


builder.Services.AddHttpContextAccessor();



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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapDefaultControllerRoute();
});
app.MapRazorPages();

app.Run();
