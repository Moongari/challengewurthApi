using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyTravelMicroservice.Model;
using MyTravelMicroservice.Repository;

namespace MyTravelMicroservice
{
    public class Program
    {
       

        
        public static  void Main(string[] args)
        {

            CreateDBIfNotExists();
            CreateHostBuilder(args).Build().Run();
            
          

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


       
        private static void CreateDBIfNotExists()
        {
            var options = new DbContextOptionsBuilder<TravelDbContext>()
            .UseInMemoryDatabase("MyTravelData").Options;

            TravelDbContext dbContext = new TravelDbContext(options);
            dbContext.DeserializeJsonDataFile();
        }
    }
}
