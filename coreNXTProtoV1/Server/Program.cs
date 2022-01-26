using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using coreNXTProtoV1.Server.Models;
using coreNXTProtoV1.Client.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
//builder.Services.AddScoped<CategoriesService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ICategoriesService, CategoriesService>(); // for DI

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7213/api/") });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("Index/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name:"default",
//    pattern:"{controller=Home}/{action=Index}"
//    );


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"
//    );

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("Index.razor");


app.Run();
