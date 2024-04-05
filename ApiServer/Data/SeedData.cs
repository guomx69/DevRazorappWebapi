using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            context.Database.EnsureCreated();
            bool isNeedSave=false;
           // Look for any roles.
            if (!context.Roles.Any())
            {   isNeedSave=true;
                context.Roles.AddRange(
                        new IdentityRole   { Name="admin"  },

                        new IdentityRole  {  Name="manager"  },

                        new IdentityRole  {  Name="member" }
               );
               // return;   // DB has been seeded
            }
            if(isNeedSave)  context.SaveChanges();
        }
    }
} 

