using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Property.Infrastructure.EF.Contexts
{
    internal class WriteDbContextFactory : IDesignTimeDbContextFactory<WriteDbContext>
    {
        public WriteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WriteDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=PropertyDb;Integrated Security=true;TrustServerCertificate=True;");

            return new WriteDbContext(optionsBuilder.Options);
        }
    }
}