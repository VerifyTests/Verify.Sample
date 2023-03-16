using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using VerifyTests.EntityFramework;

[UsesVerify]
public class EntityFrameworkTests
{
    [ModuleInitializer]
    public static void ModuleInit() =>
        VerifyEntityFramework.Initialize();

    [Fact]
    public async Task Queryable()
    {
        var context = BuildDbContext();

        var queryable = context.Companies
            .Where(company => company.Content == "value" &&
                              company.Id != Guid.Empty);
        await Verify(queryable);
    }

    static SampleDbContext BuildDbContext()
    {
        var options = new DbContextOptionsBuilder<SampleDbContext>();
        options.UseSqlServer("Server=myServerAddress;Database=myDataBase");
        return new(options.Options);
    }

    [Fact]
    public async Task Recording()
    {
        var database = await DbContextBuilder.GetDatabase("Recording");
        var data = database.Context;

        var company = new Company
        {
            Content = "Title"
        };
        data.Add(company);
        await data.SaveChangesAsync();

        EfRecording.StartRecording();

        await data.Companies
            .Where(x => x.Content == "Title")
            .ToListAsync();

        await Verify(data.Companies.Count());
    }
}