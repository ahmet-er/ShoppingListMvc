using Bitirme_Business.Business;
using Bitirme_Business.Interfaces;
using Bitirme_Data.Context;
using Bitirme_Data.Repository;
using Bitirme_Data.Repository.Interfaces;
using Bitirme_Model.Entities;
using Bitirme_Projesi.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ShoppingListDbContext>(options =>
    options.UseSqlServer(connectionString));

// Transient: geçici => her istekte yeni oluþturur
builder.Services.AddTransient<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddTransient<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddTransient<IGenericRepository<ShoppingList>, GenericRepository<ShoppingList>>();
builder.Services.AddTransient<IGenericRepository<ShoppingListItem>, GenericRepository<ShoppingListItem>>();

// Scoped: kapsam => servis her talepte ayný örneði döndürülür (örnegin HTTP istegi boyunca)
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();
builder.Services.AddScoped<ICategoryBusiness, CategoryBusiness>();
builder.Services.AddScoped<IShoppingListBusiness, ShoppingListBusiness>();
builder.Services.AddScoped<IShoppingListItemBusiness, ShoppingListItemBusiness>();
builder.Services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
builder.Services.AddScoped<IShoppingListItemRepository, ShoppingListItemRepository>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ShoppingListDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<Program>());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "editShoppingListItem",
    pattern: "ShoppingListItem/EditShoppingListItem/{sId}/{pId}",
    defaults: new { controller = "ShoppingListItem", action = "EditShoppingListItem" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}

app.Run();
