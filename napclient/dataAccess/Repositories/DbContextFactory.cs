using dataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dataModel.Repositories
{
    public class DbContextFactory : IDbContextFactory
    {
        private IConfiguration _configuration;
        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public dataContext Create()
        {
            var options = new DbContextOptionsBuilder<dataContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;

            var context = new dataContext(options);

            return context;
        }

        public dataContext CreateNoTracking()
        {
            var context = Create();

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return context;
        }
    }
}
