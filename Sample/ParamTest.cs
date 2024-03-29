﻿public class ParamTest
{
    [Theory]
    [InlineData("Value1")]
    [InlineData("Value2")]
    public Task Test(string value) =>
        Verify(value)
            .UseParameters(value);
}