public class Employee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public string? Content { get; set; }
    public int Age { get; set; }
}