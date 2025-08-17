using System.Diagnostics;
using SkiaSharp;

namespace WplacePaletteConverter;

internal static class Converter
{
	public static SKBitmap ConvertColors(SKBitmap input)
	{
		SKBitmap output = new SKBitmap(input.Info);

		using var inPixmap = input.PeekPixels();
		var inPixels = inPixmap.GetPixelSpan<SKColor>();

		using var outPixmap = output.PeekPixels();
		var outPixels = outPixmap.GetPixelSpan<SKColor>();

		Debug.Assert(outPixels.Length == inPixels.Length, "The size of the output image is somehow different than the size of the input image!");

		for (var i = 0; i < inPixels.Length; i++)
			outPixels[i] = inPixels[i].GetClosestWplaceColor();

		return output;
	}
}