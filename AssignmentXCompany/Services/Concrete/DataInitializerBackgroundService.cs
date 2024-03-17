using AssignmentXCompany.Data;
using Microsoft.EntityFrameworkCore;

namespace AssignmentXCompany.Services.Concrete
{
    public class DataInitializerBackgroundService : BackgroundService
    {
        //Task 3.1
        private readonly IServiceProvider _serviceProvider;

        public DataInitializerBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using IServiceScope scope = _serviceProvider.CreateScope();
                var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var products = await appDbContext.Products.ToListAsync(cancellationToken: stoppingToken);
                if (products.Count == 0)
                {
                    var dummyProducts = ProductService.GetInitialData();
                    await appDbContext.Products.AddRangeAsync(dummyProducts, stoppingToken);
                    await appDbContext.SaveChangesAsync(stoppingToken);
                }
                break;
            }
        }
    }
}
