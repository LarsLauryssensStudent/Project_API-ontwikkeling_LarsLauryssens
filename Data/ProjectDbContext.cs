using Microsoft.EntityFrameworkCore;
using Project_API_ontwikkeling_LarsLauryssens.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Project_API_ontwikkeling_LarsLauryssens.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Industry> Industries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed hardcoded data
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Apple", IndustryId = 1, City = "Cupertino", Country = "USA", MarketCap = 2500 },
                new Company { Id = 2, Name = "Microsoft", IndustryId = 2, City = "Redmond", Country = "USA", MarketCap = 2200 },
                new Company { Id = 3, Name = "Google", IndustryId = 1, City = "Mountain View", Country = "USA", MarketCap = 1800 },
                new Company { Id = 4, Name = "Tesla", IndustryId = 3, City = "Palo Alto", Country = "USA", MarketCap = 800 },
                new Company { Id = 5, Name = "Amazon", IndustryId = 4, City = "Seattle", Country = "USA", MarketCap = 1700 },
                new Company { Id = 6, Name = "Meta", IndustryId = 5, City = "Menlo Park", Country = "USA", MarketCap = 950 },
                new Company { Id = 7, Name = "NVIDIA", IndustryId = 1, City = "Santa Clara", Country = "USA", MarketCap = 600 },
                new Company { Id = 8, Name = "Salesforce", IndustryId = 2, City = "San Francisco", Country = "USA", MarketCap = 250 }
            );

            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, Name = "AAPL", CompanyId = 1 },
                new Stock { Id = 2, Name = "MSFT", CompanyId = 2 },
                new Stock { Id = 3, Name = "GOOGL", CompanyId = 3 },
                new Stock { Id = 4, Name = "TSLA", CompanyId = 4 },
                new Stock { Id = 5, Name = "AMZN", CompanyId = 5 },
                new Stock { Id = 6, Name = "FB", CompanyId = 6 },
                new Stock { Id = 7, Name = "NFLX", CompanyId = 6 },
                new Stock { Id = 8, Name = "NVDA", CompanyId = 7 },
                new Stock { Id = 9, Name = "ADBE", CompanyId = 2 }
            );

            modelBuilder.Entity<Industry>().HasData(
                new Industry { Id = 1, Name = "Technology" },
                new Industry { Id = 2, Name = "Software" },
                new Industry { Id = 3, Name = "Automotive" },
                new Industry { Id = 4, Name = "E-Commerce" },
                new Industry { Id = 5, Name = "Social Media" }
            );
        }
    }
}
