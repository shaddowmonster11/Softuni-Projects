using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.Repositories;
using WorldUniversity.Services;
using WorldUniversity.Services.Messaging;

namespace WorldUniversity
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
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(30);
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));
                options.AddPolicy("CreateRolePolicy",
                     policy => policy.RequireClaim("Create Role"));
                options.AddPolicy("EditRolePolicy",
                   policy => policy.RequireClaim("Edit Role"));
            });
            services.AddIdentity<IdentityUser, IdentityRole>
                (
                options => options.SignIn.RequireConfirmedAccount = true
                )
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultUI()
        .AddDefaultTokenProviders();
            services.AddTransient<IMailHelper>(serviceProvider =>
               new MailHelper(
                   this.Configuration["MailSender:Email"],
                   this.Configuration["MailSender:Password"]));
            services.Configure<IdentityOptions>(opts =>
            {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = true;
                opts.SignIn.RequireConfirmedAccount = true;
                opts.SignIn.RequireConfirmedEmail = true;
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IStudentsService, StudentsService>();
            services.AddTransient<IInstructorsService, InstructorsService>();
            services.AddTransient<ICoursesService, CoursesService>();
            services.AddTransient<IDepartmentsService, DepartmentsService>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IContactService, ContactService>();
        }
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseHsts();
            }
            IdentityDataInitializer.SeedData(userManager, roleManager);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}