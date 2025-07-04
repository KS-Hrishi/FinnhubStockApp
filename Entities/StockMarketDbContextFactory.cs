using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Entities;

public class StockMarketDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=LAPTOP-JONTFOMF;Database=FinnhubStockMarketDb;User Id=sa;Password=rishi;TrustServerCertificate=True;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
