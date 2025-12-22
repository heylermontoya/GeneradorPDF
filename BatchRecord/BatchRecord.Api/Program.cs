using BatchRecord.Api.Filters;
using BatchRecord.Api.Helper;
using BatchRecord.Infrastructure.Context;
using BatchRecord.Infrastructure.Extensions;
using BatchRecord.Infrastructure.Helper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Serilog;
using System.Reflection;
using System.Data;
using System.Text;

namespace BatchRecord.Api
{
    public partial class Program
    {
        protected Program() { }

        private static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigurationManager config = builder.Configuration;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddControllers(opts =>
            {
                opts.Filters.Add(typeof(AppExceptionFilterAttribute));
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(
                Assembly.Load("BatchRecord.Aplication"),
                typeof(Program).Assembly
            );

            builder.Services.AddAutoMapper(
                Assembly.Load("BatchRecord.Aplication")
            );

            string stringConnection = config["AuthStringConnection"]!;

            builder.Services.AddDbContext<PersistenceContext>(opt =>
            {
                opt.UseSqlServer(stringConnection, sqlopts =>
                {
                    sqlopts.MigrationsHistoryTable("_MigrationHistory", config.GetValue<string>("SchemaName"));
                    sqlopts.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    );
                });
            });

            builder.Services
                .AddHealthChecks();

            builder.Services
                .AddLogging(loggingBuilder => loggingBuilder.AddConsole()
                .AddSerilog(dispose: true));

            // Registrar IHttpContextAccessor antes de inicializar DbHelper
            builder.Services.AddHttpContextAccessor();

            // Inicializar DbHelper (necesita IConfiguration + IHttpContextAccessor)
            var tempProvider = builder.Services.BuildServiceProvider();
            var httpAccessor = tempProvider.GetRequiredService<IHttpContextAccessor>();
            DbHelper.Initialize(config, httpAccessor);

            // Registrar IDbConnection como transient: cada petición resolverá la cadena dinámica o fija
            builder.Services.AddTransient<IDbConnection>(sp =>
            {
                var http = sp.GetRequiredService<IHttpContextAccessor>();
                var path = http.HttpContext?.Request?.Path.Value ?? string.Empty;

                // Si la petición va al controlador Autenticacion usar siempre "Auth"
                var name = path.StartsWith("/api/Autenticacion", StringComparison.OrdinalIgnoreCase) ? "Auth" : "DB";

                string conn = DbHelper.GetConnectionString(name);
                return new SqlConnection(conn);
            });

            // Registrar AppDbContextDapper como transient usando la cadena correspondiente
            builder.Services.AddTransient<AppDbContextDapper>(sp =>
            {
                var http = sp.GetRequiredService<IHttpContextAccessor>();
                var path = http.HttpContext?.Request?.Path.Value ?? string.Empty;

                var name = path.StartsWith("/api/Autenticacion", StringComparison.OrdinalIgnoreCase) ? "Auth" : "DB";

                string conn = DbHelper.GetConnectionString(name);
                return new AppDbContextDapper(conn);
            });

            builder.Services
                .AddPersistence(stringConnection)
                .AddDomainServices();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new() { Title = "BatchRecord", Version = "version 1.0.0" });
                options.CustomSchemaIds(schema => schema.FullName);
                options.DocumentFilter<BasePathFilter>(config["BasePathFilter"]);
            });

            Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

            WebApplication app = builder.Build();
            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BatchRecord"));

            app.UseRouting();

            app.UseHttpMetrics().UseEndpoints(endpoints =>
            {
                endpoints.MapMetrics();
                endpoints.MapHealthChecks("/health");
            });

            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}
