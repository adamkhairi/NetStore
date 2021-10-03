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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetNgStore.Services.Categories;
using NetNgStore.Services.Products;
using NetStore.Api.Data;
using NetStore.Api.Helpers;
using NetStore.Api.Services.Auth;
using NetStore.Api.Services.CartItems;
using NetStore.Api.Services.Categories;
using NetStore.Api.Services.Orders;
using NetStore.Api.Services.Products;
using NetStore.Api.Services.UriService;
using NetStore.Api.Services.Users;
using NetStore.Shared.Models;

namespace NetStore.Api
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
            services.Configure<Jwt>(Configuration.GetSection("Jwt"));

            services.AddCors();

            //!! Add Identity with Roles ===>

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            //!! Add DBContext ===>
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );


            //!! _ DependencyInjection _ ===>
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartItemsService, CartItemsService>();
            services.AddScoped<IOrdersService, OrdersService>();

            services.AddSingleton<IUriService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");
                return new UriService(absoluteUri);
            });
            
            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>

                {
                    o.RequireHttpsMetadata = false;
                    //o.Authority = "https://localhost:5001";
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddHttpContextAccessor();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "NetStore.Api", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetStore.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllerRoute(
            //         name: "default",
            //         pattern: "{controller}/{action=Index}/{id?}");
            //     endpoints.MapRazorPages();
            // });
        }
    }
}