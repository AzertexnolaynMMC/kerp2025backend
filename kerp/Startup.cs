using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using kerp.Contexts;
using kerp.Hubs.IncidentHub;
using kerp.Hubs.PageHub;
using kerp.Service;
using kerp.Service.DsrService;
using kerp.Service.FileUploadService;
using kerp.Service.IncidentService;
using kerp.Service.MailService;
using kerp.Service.PermissionService;
using kerp.Service.PmOrderService;
using kerp.Service.PreCheckService;
using kerp.SystemModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace kerp
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("firebase-adminsdk.json")
            });

            // Veritabanı bağlantısı
            _ = services.AddDbContext<KerpContext>(options =>

            //1
              options.UseSqlServer("data source=.;Initial Catalog=kerpdb;User Id=SA;Password=Az@rtexnol@ynSQL;TrustServerCertificate=True;")

            //2
            //  options.UseSqlServer("data source=.;Initial Catalog=kerp;User Id=kerpadmin;Password=Az@rtexnol@ynSQL;TrustServerCertificate=True;")
            );


            _ = services.AddMvc();

            // CORS ayarları
            _ = services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());
            });

            // JWT ayarları
            JwtSettings jwtSettings = new();
            Configuration.Bind("Jwt", jwtSettings);
            _ = services.AddSingleton(jwtSettings);

            // JWT kimlik doğrulama yapılandırması
            _ = services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });
            _ = services.Scan(scan => scan
                // Proyektin bütün referenced assembly-lərini scan edir
                .FromApplicationDependencies(a =>
                    a.FullName != null && a.FullName.StartsWith("kerp")) // istəsəniz bunu silib hamısını scan etdirə bilərsiniz
                .AddClasses(c => c
                    .Where(t =>
                        t.Name.EndsWith("Repository") &&
                        t.Namespace != null &&
                        t.Namespace.StartsWith("kerp.Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );
            _ = services.AddScoped<IIncidentService, IncidentService>();
            _ = services.AddScoped<IMailService, MailService>();
            _ = services.AddScoped<IPmOrderService, PmOrderService>();
            _ = services.AddScoped<IPreCheckService, PreCheckService>();
            _ = services.AddScoped<IFileUploadService, FileUploadService>();
            _ = services.AddScoped<IDsrService, DsrService>();
            _ = services.AddScoped<IPermissionService, PermissionService>();
            _ = services.AddScoped<LdapService>();

            /*
            // Repository servisleri
            _ = services.AddScoped<IUserRepository, UserRepository>();
            _ = services.AddScoped<IHelperRepository, HelperRepository>();
            _ = services.AddScoped<IPageRepository, PageRepository>();
            _ = services.AddScoped<ILanguageRepository, LanguageRepository>();
            _ = services.AddScoped<IDictionaryRepository, DictionaryRepository>();
            _ = services.AddScoped<IStructureRepository, StructureRepository>();
            _ = services.AddScoped<ISectionRepository, SectionRepository>();
            _ = services.AddScoped<IWorkOrderTypeRepository, WorkOrderTypeRepository>();
            _ = services.AddScoped<IPageUserRepository, PageUserRepository>();
            _ = services.AddScoped<IManagerEmployeRepository, ManagerEmployeRepository>();
            _ = services.AddScoped<IMaterialRepository, MaterialRepository>();
            _ = services.AddScoped<IProjectRepository, ProjectRepository>();
            _ = services.AddScoped<IUserConMachineRepository, UserConMachineRepository>();

            */
            // TokenService servisi
            _ = services.AddSingleton<TokenService>();

            // SignalR
            _ = services.AddSignalR();

            // Swagger
            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kerp API", Version = "v1" });
            });

            _ = services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = app.UseCors("CorsPolicy");
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kerp API v1");
                c.RoutePrefix = string.Empty;
            });

            _ = app.UseExceptionHandler("/Error");
            _ = env.IsDevelopment() ? app.UseDeveloperExceptionPage() : app.UseHsts();
            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();

            _ = app.UseRouting();

            _ = app.UseAuthentication(); // Authentication middleware
            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
                _ = endpoints.MapHub<PageHub>("/hubs/page");
                _ = endpoints.MapHub<IncidentHub>("/hubs/IncidentHub");
                //   _ = endpoints.MapHub<DoneHub>("api/CrashDone");
                // _ = endpoints.MapHub<ResearchHub>("api/CrashResearch");
            });
        }
    }




}
