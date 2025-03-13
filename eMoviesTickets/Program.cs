using eMoviesTickets.Data;
using eMoviesTickets.Data.Cart;
using eMoviesTickets.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


//DBContext Configuration
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MoviesService>();
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<ProducersService>();
builder.Services.AddScoped <CinemasService>();
builder.Services.AddScoped<OrdersService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
builder.Services.AddSession();

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("en-BW") };
var localizationsOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-BW"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
};

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(localizationsOptions);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed database
AppDBInitializer.Seed(app);
app.Run();
