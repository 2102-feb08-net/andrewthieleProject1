using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Library.Models;
using StoreApp.DbAccess;
using StoreApp.DbAccess.Entities;
using StoreApp.DbAccess.Repositories;


namespace StoreApp.WebUI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // string filelocation = "C:/Revature/storeApp-connection-string.txt";
      // string connectionString = File.ReadAllText(filelocation);
      string connectionString = Configuration["ConnectionStrings:proj1ConnectionString"];

      services.AddDbContext<StoreProj0Context>(options =>
      {
        options.UseSqlServer(connectionString);
      });

      // ?  Add Scoped methods??
      services.AddScoped<CustomerRepository>();
      // services.AddScoped<ILocationRepository, LocationRepository>();
      services.AddScoped<LocationRepository>();
      services.AddScoped<ProductRepository>();
      services.AddScoped<OrderRepository>();
      services.AddScoped<InventoryRepository>();
      // ? DO I NEED MORE REPOSITORIES???

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreApp.WebUI", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreApp.WebUI v1"));
      }

      app.UseHttpsRedirection();
      // added my me
      app.UseStaticFiles();
      //
      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
