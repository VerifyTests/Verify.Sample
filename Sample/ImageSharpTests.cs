using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

[UsesVerify]
public class ImageSharpTests
{
    [Fact]
    public Task VerifyImage()
    {
        var image = new Image<Rgba32>(11, 11)
        {
            [5, 5] = Rgba32.ParseHex("#00000F")
        };
        return Verify(image);
    }
}