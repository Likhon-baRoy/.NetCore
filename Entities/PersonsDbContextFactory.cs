using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Entities;

public class PersonsDbContextFactory : IDesignTimeDbContextFactory<PersonsDbContext>
{
    public PersonsDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<PersonsDbContext>();
        builder.UseSqlServer(
            "Server=localhost,1435;Database=PersonsDatabase;User Id=sa;Password=YourStrong@Password1;TrustServerCertificate=True;"
        );

        return new PersonsDbContext(builder.Options);
    }
}
