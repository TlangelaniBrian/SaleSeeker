using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaleSeeker_DAL;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SaleSeekerDB");

builder.Services.AddDbContext<SaleSeekerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SaleSeekerContext>();
builder.Services.AddAuthentication().AddFacebook(option =>
{
    option.AppId = "636201925343451";
    option.AppSecret = "abfdd500c4180efadfd4cd4dfd412f65";
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
