using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Handlers;
using Logic;

namespace MachineMonitoring {
    public class Startup {
        private readonly string Q3Origins = "_Q3Origins";

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<Imachine_monitoring_poortenHandler, machine_monitoring_poortenHandler>();
            services.AddSingleton<Imachine_monitoring_poortenLogic, machine_monitoring_poortenLogic>();
            services.AddSingleton<Imonitoring_dataHandler, monitoring_dataHandler>();
            services.AddSingleton<Imonitoring_dataLogic, monitoring_dataLogic>();
            services.AddSingleton<Iproduction_dataHandler, production_dataHandler>();
            services.AddSingleton<Iproduction_dataLogic, production_dataLogic>();
            services.AddSingleton<ItreeviewHandler, treeviewHandler>();

            services.AddCors(options => {
                options.AddPolicy(Q3Origins, builder => {
                    builder.WithOrigins("http://localhost:3000");
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MachineMonitoring", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MachineMonitoring v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(Q3Origins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
