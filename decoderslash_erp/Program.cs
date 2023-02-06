using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using decoderslash_erp.Data;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<decoderslash_erpContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("decoderslash_erpContext") ?? throw new InvalidOperationException("Connection string 'decoderslash_erpContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

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
app.UseSession();
app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
