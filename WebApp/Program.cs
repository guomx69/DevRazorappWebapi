using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

using WebApp.AccessLayer;


var builder = WebApplication.CreateBuilder(args);
// builder.Logging.ClearProviders();
// builder.Logging.AddConsole();

builder.Services.AddSingleton<ApiUserDataAccess>();
builder.Services.AddTransient<IUserStore<IdentityUser>, ApiUserStore>();

builder.Services.AddSingleton<ApiRoleDataAccess>();
builder.Services.AddTransient<IRoleStore<IdentityRole>, ApiRoleStore>();

// builder.Services.AddSingleton<InMemoryUserDataAccess>();
// builder.Services.AddTransient<IUserStore<IdentityUser>, InMemoryUserStore>();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit=false;
    options.Password.RequiredLength=3;
    options.Password.RequireNonAlphanumeric=false;
    options.Password.RequireLowercase=false;
    options.Password.RequireUppercase=false;
} ).AddRoles<IdentityRole>(); //.AddDefaultIdentity<IdentityUser>.AddRoles<IdentityRole>();//.AddEntityFrameworkStores<AppDbContext>();.AddIdentity<IdentityUser,IdentityRole>


//https://stackoverflow.com/questions/56390914/when-using-services-addhttpclient-where-is-the-httpclient-created
builder.Services.AddHttpClient("test.online").ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler //localhost
            {
               ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

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
