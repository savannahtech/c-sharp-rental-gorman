using Data.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Unit.Test.Configurations;

public class TestWithSqlite : IDisposable
{
    
    private readonly SqliteConnection _connection;
    protected readonly RentalContext _rentalContext;

    public TestWithSqlite()
    {            
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        var options = new DbContextOptionsBuilder<RentalContext>()
            .UseSqlite(_connection)
            .Options;
        _rentalContext = new RentalContext(options);
        _rentalContext.Database.EnsureCreated();
    }
    
    public void Dispose()
    {
        _connection.Dispose();
    }
}