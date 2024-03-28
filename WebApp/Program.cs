using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.AccessLayer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DbApiServer");
builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddSingleton<InMemoryUserDataAccess>();
builder.Services.AddTransient<IUserStore<IdentityUser>, InMemoryUserStore>();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit=false;
    options.Password.RequiredLength=3;
    options.Password.RequireNonAlphanumeric=false;
    options.Password.RequireLowercase=false;
    options.Password.RequireUppercase=false;
} ).AddEntityFrameworkStores<AppDbContext>();



builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapRazorPages();

app.Run();
