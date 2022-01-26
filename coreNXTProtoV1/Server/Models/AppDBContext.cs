using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace coreNXTProtoV1.Server.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }
           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           {
               if(!optionsBuilder.IsConfigured)
               {
                
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConnection"));
                

               }
           }
        
        // public DbSet<Categories> Categories { get; set; }
    }
}
