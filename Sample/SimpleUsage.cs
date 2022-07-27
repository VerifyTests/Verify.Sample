[UsesVerify]
public class SimpleUsage
{
    [Fact]
    public Task VerifyString() =>
        Verify("TheValdue");
}