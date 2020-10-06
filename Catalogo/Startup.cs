using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Catalogo.DatabaseSettings;
using Catalogo.Services;
using Newtonsoft.Json.Serialization;

namespace Catalogo
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
            services.AddResponseCompression();

            services.AddCors(o => o.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0.0.0", new OpenApiInfo
                {
                    Title = "Documentação Api Catalogo",
                    Version = "v1.0.0.0",
                    Description = "Api Catalogo"
                });
            });

            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<CatalogoDataBaseSettings>(Configuration.GetSection(nameof(CatalogoDataBaseSettings)));
            services.AddSingleton<ICatalogoDataBaseSettings>(sp => sp.GetRequiredService<IOptions<CatalogoDataBaseSettings>>().Value);

            services.AddSingleton<GeneroService>();
            services.AddSingleton<FilmeService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            }

            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "doc";
                c.SwaggerEndpoint("../swagger/v1.0.0.0/swagger.json", "Documentação Api Monitor v1.0.0.0");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
