using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Web
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
            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            //services.AddEntityFrameworkSqlite().AddDbContext<AccountContext>();
            //services.AddEntityFrameworkSqlite().AddDbContext<Context>();


            services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase());




            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<AccountContext>().
              AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/signin"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            // var secretKey = "janitha_is_awesome";
            // var issuer = "janitha";
            // var audience = "resourceManager_users";
            // var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            // var tokenValidationParameters = new TokenValidationParameters
            // {
            //     ValidateIssuerSigningKey = true,
            //     IssuerSigningKey = signingKey,

            //     // Validate the JWT Issuer (iss) claim
            //     ValidateIssuer = true,
            //     ValidIssuer = issuer,

            //     // Validate the JWT Audience (aud) claim
            //     ValidateAudience = true,
            //     ValidAudience = audience
            // };


            // services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //   .AddJwtBearer(o => o.TokenValidationParameters = tokenValidationParameters);

            services.AddScoped<IManager<User>, UsersManager>();
            services.AddScoped<IRepository<User>, InMemoryUserRepository>();


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            //app.UseAuthentication();

            app.UseIdentity();

            app.UseMvc();
        }
    }
}
