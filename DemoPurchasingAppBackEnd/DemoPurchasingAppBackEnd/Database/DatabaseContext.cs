using DemoPurchasingAppBackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoPurchasingAppBackEnd.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ILogger<DatabaseContext> logger;

        public DatabaseContext(IConfiguration configuration, IWebHostEnvironment webHostEnvironment, ILogger<DatabaseContext> logger)
        {
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
            this.logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                options.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
            }
            else
            {
                options.UseSqlServer(configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
            }
        }

        public DbSet<BuyProcedure> BuyProcedures { get; set; }
    }
}
