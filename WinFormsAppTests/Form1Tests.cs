using SimpleCalculator;

[TestFixture]
[Apartment(ApartmentState.STA)]
public class Form1Tests
{
    [Test]
    public async Task FormUsage()
    {
        var form = new Form1();
        await Verify(form);
    }
}