using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Framework.EntityFrameworkCore
{
    public static class FrameworkDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FrameworkDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FrameworkDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}