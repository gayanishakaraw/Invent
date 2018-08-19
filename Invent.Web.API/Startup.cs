using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invent.Web.Business.Repositories;
using Invent.Web.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Invent.Web.API
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
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddDbContext<InventoryDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("InventoryDatabase")));

            var secretKey = Encoding.ASCII.GetBytes(Configuration.GetSection("Authentication:Secret").Value);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
                c.SwaggerDoc("v1",
                    new Info { Title = "Inventory API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter the JSON Web Token(JWT) with \"Bearer\" in the beginning", Name = "Authorization", Type = "apiKey" });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                            { "Bearer", Enumerable.Empty<string>() },
                        });
            });

            services.AddCors();

            // Dependancy Inject
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUsersBsRepository, UsersBsRepository>();
            services.AddScoped<ICategoryBsRepository, CategoryBsRepository>();
            services.AddScoped<ICompaniesBsRepository, CompaniesBsRepository>();
            services.AddScoped<ICustomersBsRepository, CustomersBsRepository>();
            services.AddScoped<IItemsBsRepository, ItemsBsRepository>();
            services.AddScoped<IItemStocksBsRepository, ItemStocksBsRepository>();
            services.AddScoped<IOrderDetailsBsRepository, OrderDetailsBsRepository>();
            services.AddScoped<IOrdersBsRepository, OrdersBsRepository>();
            services.AddScoped<IPaymentsBsRepository, PaymentsBsRepository>();
            services.AddScoped<IPermissionGroupsBsRepository, PermissionGroupsBsRepository>();
            services.AddScoped<IPermissionsBsRepository, PermissionsBsRepository>();
            services.AddScoped<IRolesBsRepository, RolesBsRepository>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API v1");
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
