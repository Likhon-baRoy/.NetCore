using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Entities;

public class Personsdbcontextfactory : IDesignTimeDbContextFactory<PersonsDbContext>
{
    public PersonsDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<PersonsDbContext>();
        builder.UseSqlServer(
            "Server=127.0.0.1,1433;Database=PersonsDatabase;User Id=sa;Password=Aa!9274sqlXX#;TrustServerCertificate=True;"
        );

        return new PersonsDbContext(builder.Options);
    }
}
