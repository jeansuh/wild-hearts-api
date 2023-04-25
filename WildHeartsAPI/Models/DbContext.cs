using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WildHeartsAPI.Models;
using System.Collections.Generic;

namespace WildHeartsAPI.Models
{
    public class WildHeartsAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public WildHeartsAPIDBContext(DbContextOptions<WildHeartsAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("WildHeartsData");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Kemono> Kemonos { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
    }
}

