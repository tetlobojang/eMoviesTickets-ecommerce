using eMoviesTickets.Data;
using eMoviesTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed database
AppDBInitializer.Seed(app);
app.Run();
