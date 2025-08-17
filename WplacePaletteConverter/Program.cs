using System.Diagnostics;
using SkiaSharp;
using WplacePaletteConverter;

if (args.Length < 1)
{
	string exeName = Process.GetCurrentProcess().ProcessName;

	Console.Error.WriteLine($"Usage: {exeName} <path to image>");
	Environment.Exit(1);
}

var inputImagePath = args[0];
var inputImageDirectory = Path.GetDirectoryName(inputImagePath) ?? string.Empty;
var inputImageFileName = Path.GetFileName(inputImagePath);
var outputImageFileName = Path.ChangeExtension(inputImageFileName, ".wplace.png");
var outputImagePath = Path.Combine(inputImageDirectory, outputImageFileName);

SKBitmap inputImage;

using (var inputStream = File.Open(inputImagePath, FileMode.Open, FileAccess.Read))
	inputImage = SKBitmap.Decode(inputStream);

var outputImage = Converter.ConvertColors(inputImage);

using (var outputStream = File.Open(outputImagePath, FileMode.Create, FileAccess.Write))
	outputImage.Encode(outputStream, SKEncodedImageFormat.Png, 100);

Console.WriteLine($"Converted image saved to \"{outputImagePath}\"");