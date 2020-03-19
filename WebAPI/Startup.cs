using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolPortalAPI.BOL.Security;
using SchoolPortalAPI.BLL;
using SchoolPortalAPI.Models;
using SchoolPortalAPI.DAL.Repositories;
using SchoolPortalAPI.ViewModels;
using SchoolPortalAPI.DAL;

namespace SchoolPortalAPI
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
            //Inject AppSettings
            AddAppSettings(services);

            services.AddMvc().SetCompatibilityVersion
                             (CompatibilityVersion.Version_2_2);

            AddSqlConnections(services);

            services.AddDefaultIdentity<AppUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<SchoolDbContext>();

            AddIdentityOptions(services);

            services.AddCors();

            //Jwt Authentication
            AddBearerAuthentication(services);

            AddRepositories(services);

            AddServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            .AllowAnyHeader()
            .AllowAnyMethod()

            );

            //ApplicationDbInitializer.SeedUsers(userManager);

            app.UseAuthentication();

            app.UseMvc();


        }

        #region Startup Helper Methods
        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IMembersRepo), typeof(MembersRepo));
        }
        private void AddServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IPaginationService<>), typeof(PaginationService<>));
        }
        private void AddIdentityOptions(IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });
        }
        private void AddSqlConnections(IServiceCollection services)
        {
            services.AddDbContext<SchoolDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
        private void AddAppSettings(IServiceCollection services)
        {
            services.Configure<AppSettingsVModel>(Configuration.GetSection("ApplicationSettings"));
        }
        private void AddBearerAuthentication(IServiceCollection services)
        {
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
        #endregion
    }
}
