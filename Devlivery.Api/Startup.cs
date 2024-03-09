using Devlivery.Authentication.Context;
using Devlivery.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Devlivery.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; }
        public Startup(
            IConfiguration configuration, 
            IServiceCollection services)
        {
            Configuration = configuration;
            Services = services;
        }
        public static ServiceCollection ConfiguraServicos()
        {
            var appsettings = ObterAppsettings();
            var connection = appsettings.GetSection("ConnectionStrings").GetSection("DefaultConnection");
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(connection);
            //services.AddControllers();
            services.AddEndpointsApiExplorer();
            /*
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Usuario",
                    policy => policy.RequireRole("Usuario"));
            });*/
            var connectiongString = ObterAppsettings().GetConnectionString("DefaultConnection");// Configuration.GetConnectionString("DefaultConnection");
            // Configurações do Identity, Entity Framework, JWT, etc.
            services.AddDbContext<AplicacaoDbContext>(options =>
                options.UseSqlServer(connectiongString));

            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(connectiongString));

            services.AddHealthChecks();

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            return services;
        }
        public static IConfiguration ObterAppsettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwaggerUI();
            }
            /*
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }*/
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            //app.UseBasicApplicationBuilder();

            //app.MapIdentityApi<Usuario>();
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();
            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/
        }
    }
}

/*
 * 
 *             services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AplicacaoDbContext>()
                .AddDefaultTokenProviders();

            //services.AddControllers();
            /*
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My Service",
                    Version = "v1"
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        // Configurações do JWT
                    };
                });


services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "ThisismySecretKey",
            ValidAudience = "Test.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKey"))
        };
    });

services.AddAuthorization(options =>
{

    options.AddPolicy("Usuario",
        policy => policy.RequireRole("Usuario"));
    /*
    options.AddPolicy("Admin", policy =>
    policy.RequireRole("Admin")); 
    options.AddPolicy("Aluno",
        policy => policy.RequireRole("Aluno"));

});
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configurações do ambiente (ex.: tratamento de erros, etc.)
            // ...

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Service V1");
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }*/
