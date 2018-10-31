using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Core;
using ToDoApp.Infrastructure.Business;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using ToDoApp.Infrastructure.Data;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.SpaServices.Extensions;

namespace ToDoApp
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connection));
            services.AddMvc().AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            
            services.AddAutoMapper(); // Adding automapper
                                     //JWT-
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
             ValidateIssuer = true, // укзывает, будет ли валидироваться издатель при валидации токена
             ValidIssuer = AuthOptions.ISSUER, // строка, представляющая издателя
             ValidateAudience = true, // будет ли валидироваться потребитель токена
             ValidAudience = AuthOptions.AUDIENCE,// установка потребителя токена
             ValidateLifetime = true,// будет ли валидироваться время существования
             IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),// установка ключа безопасности
             ValidateIssuerSigningKey = true, // валидация ключа безопасности
            };
        });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseCors("CorsPolicy");         
            app.UseMvc();
        }
    }
}
