using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Octopus.Client.Repositories.Async;
using News_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace News_WebAPI
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
            var tokenProvider = new TokenProvider(
                Configuration["Jwt:Issuer"], 
                Configuration["Jwt:Audience"], 
                Configuration["Jwt:SecretKey"]);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(ops =>
            {
                ops.RequireHttpsMetadata = false;
                ops.TokenValidationParameters = tokenProvider.GetTokenValidation();
            });

            services.AddAuthorization(a =>
            {
                a.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes
                (
                    JwtBearerDefaults.AuthenticationScheme
                 )
                .RequireAuthenticatedUser()
                .Build();
            });

            services.AddSingleton<ITokenProvider>(tokenProvider);
            services.AddCors();
                     

            services.AddDbContext<Data.NewsServerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("NewsServer"));
            });

            services.AddControllers();

            //services.AddTransient<IUserRepository, >();
            //services.AddTransient<ITokenService, TokenService>();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidAudience = Configuration["Jwt:Issuer"],
            //        IssuerSigningKey = new
            //        SymmetricSecurityKey
            //        (Encoding.UTF8.GetBytes
            //        (Configuration["Jwt:Key"]))
            //    };
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "News_WebAPI", Version = "v1" });
                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "News_WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors((ops) =>
            {
                ops.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
            });
        }
    }
}
