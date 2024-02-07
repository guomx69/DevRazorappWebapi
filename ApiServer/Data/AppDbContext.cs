using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ApiServer.Models;

namespace WebApp.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Post>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Posts)
            .UsingEntity("TestPostsToTagsJoin");
    }
    public DbSet<PrayerMd> TestPrayers { get; set; }=null!;
    public DbSet<Post> TestPosts { get; set; }=null!;
    public DbSet<Tag> TestTags { get; set; }=null!;
    public DbSet<CityMd> TestCities { get; set; }=null!;
}
