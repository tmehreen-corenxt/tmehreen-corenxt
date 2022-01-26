using coreNXTProtoV1.Client;
using coreNXTProtoV1.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddSingleton<ICategoriesService, CategoriesService>();

builder.Services.AddSingleton(client => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//public IConfiguration Configuration { get; set; }
//var sqlconn = new AppDBContext(Configuration.GetConnectionString("DBConnection"));
//builder.Services.AddSingleton(sqlconn);
/*builder.Services.AddHttpClient<iCategoriesService, CategoriesService>(client =>
{
  client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
}
);*/

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();
