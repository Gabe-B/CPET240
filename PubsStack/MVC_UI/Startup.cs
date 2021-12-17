using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using ViewModels;
using PubsServiceBus;
using Repositories;
using MySql.Data.MySqlClient;

namespace MVC_UI
{
	/// <summary>
	/// startup class
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// configuration
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// add service to container
		/// </summary>
		/// <param name="services"></param>
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			string database = Configuration["Configuration:pubsDBSConnectionString"];

			//setup repos and service

			Repositories.authorDBRepo auRepo = new authorDBRepo(database);
			Repositories.BookRepoDB bRepo = new BookRepoDB(database);

			PubsServiceBus.ServiceBus service = new PubsServiceBus.ServiceBus(auRepo, bRepo);

			services.AddSingleton(service);

			services.AddSwaggerGen();
		}

		/// <summary>
		/// configures http request pipeline
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
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

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
