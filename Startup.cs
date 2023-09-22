using LNTADSpreadsheets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNTADSpreadsheets
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
			services.AddControllersWithViews();
			string dbConnectionString = Configuration.GetConnectionString("DefaultConnection");
			
			services.AddDbContext<AppDBContext>(options => options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));
			services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();
			services.AddDistributedMemoryCache();
			services.AddSession(options =>
			{
				// Configure session options here, if needed.
				options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjust timeout as per your requirements.
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});


			services.AddRazorPages();
			//services.Configure<DirectorySettingsModel>(Configuration.GetSection("DirectorySettings"));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			// Add session middleware
			app.UseSession();

			app.UseEndpoints(endpoints =>
			{
				// Custom route for the first controller
				endpoints.MapControllerRoute(
					name: "fasbController",
					pattern: "fasbcompare/{action=Index}/{id?}",
					defaults: new { controller = "FasbCompareController" }); // Replace "CustomController1" with the actual controller name

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Login}/{action=Index}/{id?}");
			});
		}
	}
}
