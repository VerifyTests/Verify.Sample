[UsesVerify]
public class SimpleUsage
{
    [Fact]
    public async Task VerifyString() =>
        await Verify("TheValue");
}