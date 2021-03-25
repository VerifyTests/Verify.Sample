using System.Collections.Generic;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class ParamTest
{
    [Theory]
    [MemberData(nameof(GetData))]
    public Task Test(string value)
    {
        return Verifier.Verify(value)
            .UseParameters(value);
    }

    public static IEnumerable<object[]> GetData()
    {
        yield return new object[] {"Value1"};
        yield return new object[] {"Value2"};
    }
}