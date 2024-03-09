using Devlivery.Authentication.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Devlivery.Authentication
{
    public class Startup
    {        //readonly

        public IConfiguration Configuration { get; }

        //public Startup(IConfiguration configuration){_configuration = configuration;}

        //public static ServiceCollection ConfiguraServicos()
        public static ServiceCollection ConfiguraServicos()
        {
            /*  "ConnectionStrings": "DefaultConnection*/
            var appsettings = ObterAppsettings();
            var connection = appsettings.GetSection("ConnectionStrings").GetSection("DefaultConnection");
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(connection);
            //var services = new ServiceCollection();
            services.AddControllers();
            //services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();


            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(ObterAppsettings().GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            /*
            services.AddIdentityCore<Usuario>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddApiEndpoints();*/
            //services.AddIdentityConfiguration(Configuration);

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
                    policy => policy.RequireRole("Aluno"));*/

            });

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            //services.BuildServiceProvider();
            return services;
        }

        public static IConfiguration ObterAppsettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

    //IApplicationBuilder alterar  WebApplication
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cooperchip Identidade - v1");
            });

            //app.UseBasicApplicationBuilder();

            //app.MapIdentityApi<Usuario>();
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



/*
 * 
 * 
 *         public Startup()
{
var builder = new ConfigurationBuilder()
    .SetBasePath(hostEnvironment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

if (hostEnvironment.IsDevelopment() || hostEnvironment.IsStaging() || hostEnvironment.IsProduction())
{
    builder.AddUserSecrets<Startup>();
}

Configuration = builder.Build();
}
 * services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
ValidateIssuer = true,
ValidateAudience = true,
ValidateLifetime = true,
ValidateIssuerSigningKey = true,
ValidIssuer = "seu-issuer",
ValidAudience = "seu-audience",
IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sua-chave-secreta"))
}; //var t = Configuration.GetConnectionString("SqlServerConnection");
//services.AddScoped<IUsuarioService, UsuarioService>();
//var options = new DbContextOptionsBuilder<AuthDbContext>().UseSqlServer("connectionString").Options;

});*/