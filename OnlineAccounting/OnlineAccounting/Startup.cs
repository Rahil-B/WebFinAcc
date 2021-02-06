using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Accounting.Repositories;
using OnlineAccounting.Models.Purchase.Repositories;
using OnlineAccounting.Models.Repositories;
using OnlineAccounting.Models.Sales.Repositories;
using OnlineAccounting.Models.User;

namespace OnlineAccounting
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
            services.AddDbContextPool<OnlineAccountingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DemoCoreIdentityDb")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<OnlineAccountingDbContext>();
            
            services.AddScoped<IFinancialAccountRepository, SQLFinancialAccountRepository>();
            services.AddScoped<IItemRepository, SQLItemRepository>(); 
            services.AddScoped<IJournalEntryRepository, SQLJournalEntryRepository>();
            services.AddScoped<ILedgerEntryRepository, SQLLedgerEntryRepository>();

            services.AddScoped<ICustomerRepository, SQLCustomerRepository>();
            services.AddScoped<ISalesOrderRepository, SQLSalesOrderRepository>();
            services.AddScoped<IDeliveryChallanRepository, SQLDeliveryChallanRepository>();
            services.AddScoped<IInvoiceRepository, SQLInvoiceRepository>();
            services.AddScoped<IItemDetailRepository, SQLItemDetailRepository>();
            services.AddScoped<IPaymentReceivedRepository, SQLPaymentReceivedRepository>();

            services.AddScoped<IBillRepository, SQLBillRepository>();
            services.AddScoped<IBillItemDetailRepository, SQLBillItemDetailRepository>();
            services.AddScoped<IExpenseRepository, SQLExpenseRepository>();
            services.AddScoped<IPaymentsMadeRepository, SQLPaymentsMadeRepository>();
            services.AddScoped<IPurchaseOrderRepository, SQLPurchaseOrderRepository>();
            services.AddScoped<IPOrderItemDetailRepository, SQLPOrderItemDetailRepository>();
            services.AddScoped<IVendorRepository, SQLVendorRepository>();
            services.AddControllersWithViews(config => { 
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
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

            app.UseAuthentication();

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