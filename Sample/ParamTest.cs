[UsesVerify]
public class ParamTest
{
    [Theory]
    [InlineData("Value1")]
    [InlineData("Value2")]
    public Task Test(string value)
    {
        return Verifier.Verify(value)
            .UseParameters(value);
    }
}