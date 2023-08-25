
using AeCAPI.Data;
using AeCAPI.Interface;
using AeCAPI.Service;
using Microsoft.OpenApi.Models;

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

            string connectionString = Configuration.GetConnectionString("DefaultConnection"); 

            services.AddScoped<ICptecService, CptecService>();
            services.AddScoped<ICidadeService>(provider => new CidadeService(connectionString)); 
            services.AddScoped<IAeroportoService>(provider => new AeroportoService(connectionString)); 
            services.AddScoped<IClimaService>(provider => new ClimaService(connectionString)); 
            services.AddScoped<ILogService>(provider => new LogService(connectionString)); 
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEndAeC", Version = "v1" });
            });
            services.AddMvc();
            services.AddCors();
            services.AddControllers();
            services.AddHttpClient();
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
                    throw; 
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
