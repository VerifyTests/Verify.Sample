using EfLocalDb;
using VerifyTests.EntityFramework;

// LocalDb is used to make the sample simpler.
// Replace with a real DbContext
public static class DbContextBuilder
{
    static DbContextBuilder() =>
        sqlInstance = new(
            buildTemplate: CreateDb,
            constructInstance: builder =>
            {
                builder.EnableRecording();
                return new(builder.Options);
            });

    static SqlInstance<SampleDbContext> sqlInstance;

    static async Task CreateDb(SampleDbContext data)
    {
        await data.Database.EnsureCreatedAsync();

        var company1 = new Company
        {
            Content = "Company1"
        };
        var employee1 = new Employee
        {
            CompanyId = company1.Id,
            Content = "Employee1",
            Age = 25
        };
        var employee2 = new Employee
        {
            CompanyId = company1.Id,
            Content = "Employee2",
            Age = 31
        };
        var company2 = new Company
        {
            Content = "Company2"
        };
        var employee4 = new Employee
        {
            CompanyId = company2.Id,
            Content = "Employee4",
            Age = 34
        };
        var company3 = new Company
        {
            Content = "Company3"
        };
        var company4 = new Company
        {
            Content = "Company4"
        };
        data.AddRange(company1, employee1, employee2, company2, company3, company4, employee4);
        await data.SaveChangesAsync();
    }

    public static Task<SqlDatabase<SampleDbContext>> GetDatabase(string suffix)
        => sqlInstance.Build(suffix);
}