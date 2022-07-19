using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Spijodic_Melika.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Spijodic_Melika
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
            services.AddDbContext<ArticleDbContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("mem_db")));
            services.AddControllers();
            
            // Register Swagger generator

            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
                    Title = "Spijodic_Melika", 
                    Version = "v1" 
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Spijodic_Melika.xml");
                options.IncludeXmlComments(filePath);
            });
  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Specifying the Swagger JSON endpoint
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Melika Spijodic API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ArticleDbContext>();
            FirstData(context);
        }

        public static void FirstData(ArticleDbContext context)
        {
            Article a1 = new Article()
            {
                Id = 1,
                Number = "article1",
                Price = 150.00,
                Date = new DateTime(2022, 7, 15)
            };

            Article a2 = new Article()
            {
                Id = 2,
                Number = "article2",
                Price = 50.00,
                Date = new DateTime(2022, 7, 14)
            };

            Article a3 = new Article()
            {
                Id = 3,
                Number = "article3",
                Price = 10.00,
                Date = new DateTime(2022, 7, 13)
            };

            Article a4 = new Article()
            {
                Id = 4,
                Number = "article4",
                Price = 100.00,
                Date = new DateTime(2022, 7, 14)
            };

            Article a5 = new Article()
            {
                Id = 5,
                Number = "article5",
                Price = 300.00,
                Date = new DateTime(2022, 7, 15)
            };

            Article a6 = new Article()
            {
                Id = 6,
                Number = "article6",
                Price = 35.00,
                Date = new DateTime(2022, 7, 13)
            };

            Article a7 = new Article()
            {
                Id = 7,
                Number = "article7",
                Price = 235.00,
                Date = new DateTime(2022, 7, 13)
            };

            Article a8 = new Article()
            {
                Id = 8,
                Number = "article8",
                Price = 99.00,
                Date = new DateTime(2022, 7, 15)
            };

            Article a9 = new Article()
            {
                Id = 9,
                Number = "article9",
                Price = 87.00,
                Date = new DateTime(2022, 7, 14)
            };

            Article a10 = new Article()
            {
                Id = 10,
                Number = "article10",
                Price = 105.00,
                Date = new DateTime(2022, 7, 12)
            };

            Article a1_1 = new Article()
            {
                Id = 11,
                Number = "article1",
                Price = 150.00,
                Date = new DateTime(2022, 7, 11)
            };

            Article a2_1 = new Article()
            {
                Id = 12,
                Number = "article2",
                Price = 50.00,
                Date = new DateTime(2022, 7, 10)
            };

            Article a3_1 = new Article()
            {
                Id = 13,
                Number = "article3",
                Price = 10.00,
                Date = new DateTime(2022, 7, 12)
            };

            Article a4_1 = new Article()
            {
                Id = 14,
                Number = "article4",
                Price = 100.00,
                Date = new DateTime(2022, 7, 11)
            };

            Article a5_1 = new Article()
            {
                Id = 15,
                Number = "article5",
                Price = 300.00,
                Date = new DateTime(2022, 7, 10)
            };

            Article a6_1 = new Article()
            {
                Id = 16,
                Number = "article6",
                Price = 35.00,
                Date = new DateTime(2022, 7, 12)
            };

            Article a7_1 = new Article()
            {
                Id = 17,
                Number = "article7",
                Price = 235.00,
                Date = new DateTime(2022, 7, 11)
            };

            Article a8_1 = new Article()
            {
                Id = 18,
                Number = "article8",
                Price = 99.00,
                Date = new DateTime(2022, 7, 10)
            };

            Article a9_1 = new Article()
            {
                Id = 19,
                Number = "article9",
                Price = 87.00,
                Date = new DateTime(2022, 7, 12)
            };

            Article a10_1 = new Article()
            {
                Id = 20,
                Number = "article10",
                Price = 105.00,
                Date = new DateTime(2022, 7, 11)
            };

            context.Articles.Add(a1);
            context.Articles.Add(a2);
            context.Articles.Add(a3);
            context.Articles.Add(a4);
            context.Articles.Add(a5);
            context.Articles.Add(a6);
            context.Articles.Add(a7);
            context.Articles.Add(a8);
            context.Articles.Add(a9);
            context.Articles.Add(a10);

            context.Articles.Add(a1_1);
            context.Articles.Add(a2_1);
            context.Articles.Add(a3_1);
            context.Articles.Add(a4_1);
            context.Articles.Add(a5_1);
            context.Articles.Add(a6_1);
            context.Articles.Add(a7_1);
            context.Articles.Add(a8_1);
            context.Articles.Add(a9_1);
            context.Articles.Add(a10_1);

            context.SaveChanges();
        }

    }
}
