using SkiaSharp;
using Wacton.Unicolour;

// Save on unnecessary "U"s
using Unicolor = Wacton.Unicolour.Unicolour;

namespace WplacePaletteConverter;

internal static class Extensions
{
	private static readonly Dictionary<SKColor, SKColor> ColorCache = [];

	public static SKColor GetClosestWplaceColor(this SKColor color)
	{
		// Fully transparent pixels are easy, so check that first
		if (color.Alpha == 0)
			return color;

		if (ColorCache.TryGetValue(color, out var bestColor))
			return bestColor;

		var bestDistance = double.PositiveInfinity;

		foreach (var testColor in Palette.AllColors)
		{
			var euclideanDistance = GetEuclideanDistanceRgb(color, testColor);

			if (euclideanDistance < bestDistance)
			{
				bestDistance = euclideanDistance;
				bestColor = testColor;
			}
		}

		var (bestR, bestG, bestB) = bestColor;
		var result = new SKColor(bestR, bestG, bestB, color.Alpha);

		ColorCache[color] = result;

		return result;
	}

#pragma warning disable IDE0051 // Keep various methods to try in case one leads to better results
	private static double GetEuclideanDistanceRgb(SKColor first, SKColor second)
	{
		var (firstR, firstG, firstB) = first;
		var (secondR, secondG, secondB) = second;
		var distR = firstR - secondR;
		var distG = firstG - secondG;
		var distB = firstB - secondB;

		return Math.Sqrt(( distR * distR ) + ( distG * distG ) + ( distB * distB ));
	}

	private static double GetEuclideanDistanceHsv(SKColor first, SKColor second)
	{
		first.ToHsv(out var firstH, out var firstS, out var firstV);
		second.ToHsv(out var secondH, out var secondS, out var secondV);

		var distH = firstH - secondH;
		var distS = firstS - secondS;
		var distV = firstV - secondV;

		return Math.Sqrt(( distH * distH ) + ( distS * distS ) + ( distV * distV ));
	}

	private static double GetEuclideanDistanceOklab(SKColor first, SKColor second)
	{
		var firstF = (SKColorF) first;
		var secondF = (SKColorF) second;

		var firstOklab = new Unicolor(ColourSpace.Rgb, firstF.Red, firstF.Green, firstF.Blue).Oklab;
		var secondOklab = new Unicolor(ColourSpace.Rgb, secondF.Red, secondF.Green, secondF.Blue).Oklab;

		var distL = firstOklab.L - secondOklab.L;
		var distA = firstOklab.A - secondOklab.A;
		var distB = firstOklab.B - secondOklab.B;

		return Math.Sqrt(( distL * distL ) + ( distA * distA ) + ( distB * distB ));
	}
#pragma warning restore IDE0051

	private static void Deconstruct(this SKColor color, out byte red, out byte green, out byte blue)
	{
		red = color.Red;
		green = color.Green;
		blue = color.Blue;
	}
}