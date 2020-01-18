namespace Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class DbContextFactory : DesignTimeDbContextFactoryBase<ReactivitiesDbContext>
    {
        protected override ReactivitiesDbContext CreateNewInstance(DbContextOptions<ReactivitiesDbContext> options)
        {
            return new ReactivitiesDbContext(options);
        }
    }
}
