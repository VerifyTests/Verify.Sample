using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

public class ImageSharpTests
{
    [Fact]
    public Task VerifyImage()
    {
        var image = new Image<Rgba32>(11, 11)
        {
            [5, 5] = Color.ParseHex("#00000F").ToPixel<Rgba32>()
        };
        return Verify(image);
    }
}