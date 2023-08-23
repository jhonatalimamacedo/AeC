using AeCAPI.Data;
using AeCAPI.Interface;
using AeCAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Data.Entity;

namespace AeCAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AeCContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                sqlServer => sqlServer.MigrationsAssembly("banco")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEndAeC", Version = "v1" });
            });
            services.AddScoped<ICptecService, CptecService>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IAeroportoService, AeroportoService>();
            services.AddScoped<IClimaService, ClimaService>();
            services.AddScoped<ILogService, LogService>();
            services.AddMvc();
            services.AddCors();
            services.AddControllers();
            services.AddHttpClient();

            // Outros serviços e configurações podem ser adicionados aqui
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEndAeC v1"));
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            

            // Adicione o Middleware para capturar exceções e gravar logs
            app.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();
                }
                catch (Exception ex)
                {
                    var logger = context.RequestServices.GetRequiredService<ILogger<Startup>>();
                    logger.LogError(ex, "An unhandled exception occurred.");
                    throw; // Rethrow the exception to be handled by the configured error handler
                }
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

         

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
