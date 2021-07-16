using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WorldUniversity.Data;
using WorldUniversity.Repositories;
using WorldUniversity.Services;
using WorldUniversity.Services.Cloudinary;
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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(30);
            });
            services.AddSession();
            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            });
            services.AddTransient<ICloudinaryService>(serviceProvider =>
               new CloudinaryService(this.Configuration["Cloudinary:CloudName"], this.Configuration["Cloudinary:ApiKey"],
                   this.Configuration["Cloudinary:ApiSecret"]));
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
            //Optionaly you can use claims
            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));
                options.AddPolicy("CreateRolePolicy",
                     policy => policy.RequireClaim("Create Role"));
                options.AddPolicy("EditRolePolicy",
                   policy => policy.RequireClaim("Edit Role"));
                options.AddPolicy("DeleteUserPolicy",
                     policy => policy.RequireClaim("Delete User"));
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
            services.AddControllersWithViews(
           options =>
           {
               options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

           }).AddRazorRuntimeCompilation();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
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
            app.UseSession();
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