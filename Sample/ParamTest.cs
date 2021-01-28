using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class ParamTest
{
    [Theory]
    [MemberData(nameof(GetData))]
    public Task Test(string file)
    {
        var info = new FileInfo(file);
        return Verifier.Verify(info.Length)
            .UseParameters(Path.GetFileNameWithoutExtension(file));
    }

    public static IEnumerable<object[]> GetData()
    {
        foreach (var file in Directory.EnumerateFiles(Environment.CurrentDirectory, "*.yaml"))
        {
            yield return new object[] {file};
        }
    }
}