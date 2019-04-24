using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using EquipmentInventory.Configurations;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;
using EquipmentInventory.Models;
using EquipmentInventory.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Remotion.Linq.Clauses;


namespace EquipmentInventory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            
           
            services.AddDbContext<InventoryEquipmentContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            
            /*CREATE INSTANCE AUTOFAC BUILDER */
            var builder = new ContainerBuilder();
            
            builder.Populate(services);

             /*AUTO-MAPPER BUILD*/
            builder.AddMapperProfiles().Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>()
                .SingleInstance();


            builder.RegisterType<SpecificationQueryableBuilder<Equipment>>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .InstancePerLifetimeScope();
                        
            Container = builder.Build();
            return new AutofacServiceProvider(Container);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMapper autoMapper, 
            ILoggerFactory loggerFactory,IApplicationLifetime applicationLifetime )
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            autoMapper.ConfigurationProvider.AssertConfigurationIsValid();
           
            
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();
                
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var dbContext = serviceScope.ServiceProvider.GetRequiredService<InventoryEquipmentContext>();
                  //  dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
               
                }
            }
            else
            {
                app.UseHsts();
            }

//            app.UseHttpsRedirection();


            app.UseMvc();
            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());


        }
    }
}
