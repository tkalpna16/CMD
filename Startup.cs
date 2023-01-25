using System;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Server.IIS;
using CivilMasterData.Models;
using CivilMasterData.Data;
using CivilMasterData.Models.PriceList;
using CivilMasterData.Models.Users;
using CivilMasterData.Controllers.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CivilMasterData
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string oracleConn = Configuration.GetValue<string>("Oracle:ConnectionString:DefaultConnection");
            oracleConn =  AESService.Decrypt(oracleConn);
            string oracleRelease = Configuration.GetValue<string>("Oracle:Version");

            services.AddDbContext<HomeContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<USERSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PBSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<TAGTYPESContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PROJECTSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PROJECTSETTINGSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PROPOSEDQUANTITYContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<ItemListCreationContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<MATERIALWORKGROUPSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<MAINITEMSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<MODELCONNECTORContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<ENGINEERING_STATUSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<SECONDARY_ITEMContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<SECONDARY_ITEM_QUANTITYContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PLANNINGSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<MAIN_ITEM_QUANTITYContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<MAIN_ITEM_QUANTITYContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<QuantityManagerContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<ViewManagerContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<ReportsContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<HoldManagerContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<DLGENERATORContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PRICECODEDEFINITIONSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PRICECODESContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PRICEFAMILIESVALUESContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PRICECONDITIONSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PriceEvaluatorContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<OBJECTCODESContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<ADMINContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<MAINITEMPARAMETERSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<WORKINGPACKAGESContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<MAINITEMPLANNINGDATESContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PROJECTUSERSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));

            // Steel
            services.AddDbContext<VENDORSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<MATERIALREQUESTSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<PURCHASEORDERSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<VENDORDATAREGISTERContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<COMMODITYCODESContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<STEELPLANNINGSContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<SteelQuantityManagerContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            services.AddDbContext<SteelItemListCreationContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));

            services.AddDbContext<DETAILERDRContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));

            services.AddDbContext<EventLogContext>(options => options.UseOracle(oracleConn, opt => opt.UseOracleSQLCompatibility(oracleRelease)));
            
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
               // options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMemoryCache();//added

            services.AddRazorPages();

            // Add localization support
            services.AddLocalization(config => { config.ResourcesPath = "Resources"; });
            services.AddTransient<ISharedResource, SharedResource>();

            // Set Form Request Limit
            services.Configure<FormOptions>(options =>
            {
                options.MultipartHeadersLengthLimit = 1048576000;
                options.BufferBodyLengthLimit = 1048576000;
                options.MultipartBodyLengthLimit = 1048576000;
                options.KeyLengthLimit = 1048576000;
                options.ValueLengthLimit = 1048576000;
            });
            // Add access to configuration
            services.AddSingleton(Configuration);

            services.AddTransient<IClaimsTransformation, TecnimontClaimsTransformer>();
           services.AddAuthentication(IISServerDefaults.AuthenticationScheme);
           
            services.AddKendo();
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
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseRouting();
            
            // Localization
            string defaultLanguage = Configuration.GetValue<string>("AppSettings:DefaultLanguage");
            var supportedCultures = new[]
            {
                new CultureInfo(defaultLanguage)
            };
            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(defaultLanguage);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            //Add Authentication service
            app.UseAuthentication();
            app.UseAuthorization();

            //Add User session
            app.UseSession();

            //Add JWToken to all incoming HTTP Request Header
            app.Use(async (context, next) =>
            {
                try
                {
                   //var appsession =  context.Session.GetString("App");
                   // if (!string.IsNullOrEmpty(appsession))
                   // {
                   //     context.Request.Headers.Add("Authorization", "Bearer " + appsession);
                   // }


                    // Block Handle token based session
                    var JWToken = context.Session.GetString("JWToken");
                    if (!string.IsNullOrEmpty(JWToken))
                    {
                        context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                await next();
            });               


            // Add Middleware for Current User Status
            app.UseEventLogCaptureMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseHttpsRedirection();
        }
    }
}
