using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bloggingEngine.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bloggingEngine
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<BloggingContext>(opt => opt.UseSqlite(@"Data Source=blog_db.db"));
            //services.AddDbContext<BloggingContext>(opt => opt.UseInMemoryDatabase("xyz"));
            // services.AddDbContext<BloggingContext>(opt => opt.UseInMemoryDatabase("bloggingctx"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BloggingContext bloggingContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            // bloggingContext.Posts.Add(new Post
            // {
            //     AuthorId = 1,
            //     Title = "This is my first blogpost",
            //     Content = "The first blogpost is here.",
            //     CreatedAtAction = DateTime.Now
            // });

            // bloggingContext.Posts.Add(new Post
            // {
            //     AuthorId = 2,
            //     Title = "This is my second blogpost",
            //     Content = "The first second is here.",
            //     CreatedAtAction = DateTime.Now
            // });

            // bloggingContext.Comments.Add(new Comment
            // {
            //     PostId = 1,
            //     AuthorId = 1,
            //     Content = "C11",
            //     CreatedAtAction = DateTime.Now
            // });
            // bloggingContext.Comments.Add(new Comment
            // {
            //     PostId = 1,
            //     AuthorId = 2,
            //     Content = "C12",
            //     CreatedAtAction = DateTime.Now
            // });

            // bloggingContext.Comments.Add(new Comment
            // {
            //     PostId = 2,
            //     AuthorId = 2,
            //     Content = "C21",
            //     CreatedAtAction = DateTime.Now
            // });
            // bloggingContext.Comments.Add(new Comment
            // {
            //     PostId = 2,
            //     AuthorId = 2,
            //     Content = "C22",
            //     CreatedAtAction = DateTime.Now
            // });

            // bloggingContext.Authors.Add(new Author
            // {
            //     AuthorName = "Rafael Fernandez",
            //     CreatedAtAction = DateTime.Now
            // });

            // bloggingContext.Authors.Add(new Author
            // {
            //     AuthorName = "John Doe",
            //     CreatedAtAction = DateTime.Now
            // });

            // bloggingContext.SaveChanges();
            
        }
    }
}
