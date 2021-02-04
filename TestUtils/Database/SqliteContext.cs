using System.Data.Common;
using System.Threading.Tasks;
using Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models.Base;

namespace TestUtils
{
    public class SqliteContext : DatabaseContext
    {
        private readonly DbConnection _connection;

        public SqliteContext()
            : base(new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(new SqliteConnection("Filename=:memory:"))
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(x =>
                {
                    x.Ignore(InMemoryEventId.TransactionIgnoredWarning);
                    x.Log(RelationalEventId.MultipleCollectionIncludeWarning);
                })
                .Options)
        {
            _connection = Database.GetDbConnection();
            _connection.Open();

            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public override void Dispose()
        {
            Database.EnsureDeleted();
            _connection?.Dispose();
            base.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await Database.EnsureDeletedAsync();
            await _connection.DisposeAsync();
            await base.DisposeAsync();
        }

        public async Task<T> SaveAsync<T>(T model)
            where T : BaseModel
        {
            var entry = await AddAsync(model);
            await SaveChangesAsync();
            return entry.Entity;
        }
    }
}
