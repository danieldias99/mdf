﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MDF.Models.ClassesDeDominio;
using Microsoft.EntityFrameworkCore;

namespace MDF
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
            //services.AddDbContext<MDFContext>(opt => opt.UseSqlServer("Server=localhost\\SQLEXPRESS02;Database=ME;Trusted_Connection=True;"));
            services.AddDbContext<MDFContext>(opt => opt.UseSqlServer("Server=tcp:lapr5-019.database.windows.net,1433;Initial Catalog=lapr5;Persist Security Info=False;User ID=admin019;Password=lapr5-019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            //services.AddDbContext<MDFContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Database")));

            //services.AddDbContext<LAPR5DBContext>(opt => opt.UseInMemoryDatabase("todoList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddCors(opt =>
            {
                opt.AddPolicy("IT3Client",
                b =>
                {
                    b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("IT3Client");
        }
    }
}
