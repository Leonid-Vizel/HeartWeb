using HeartWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(30);
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
bool development = builder.Environment.IsDevelopment();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString(development ? "DefaultConnection" : "DeployConnection")));

var app = builder.Build();

if (!development)
{
    app.UseExceptionHandler("/Error/Code/500");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/Code/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Med}/{action=Index}/{id?}");
app.Run();