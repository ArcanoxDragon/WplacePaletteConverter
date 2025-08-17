using SkiaSharp;

namespace WplacePaletteConverter;

internal static class Palette
{
	public static readonly SKColor Black       = new(0, 0, 0);
	public static readonly SKColor DarkGray    = new(60, 60, 60);
	public static readonly SKColor Gray        = new(120, 120, 120);
	public static readonly SKColor LightGray   = new(210, 210, 210);
	public static readonly SKColor White       = new(255, 255, 255);
	public static readonly SKColor DeepRed     = new(96, 0, 24);
	public static readonly SKColor Red         = new(237, 28, 36);
	public static readonly SKColor Orange      = new(255, 127, 39);
	public static readonly SKColor Gold        = new(246, 170, 9);
	public static readonly SKColor Yellow      = new(249, 221, 59);
	public static readonly SKColor LightYellow = new(255, 250, 188);
	public static readonly SKColor DarkGreen   = new(14, 185, 104);
	public static readonly SKColor Green       = new(19, 230, 123);
	public static readonly SKColor LightGreen  = new(135, 255, 94);
	public static readonly SKColor DarkTeal    = new(12, 129, 110);
	public static readonly SKColor Teal        = new(16, 174, 166);
	public static readonly SKColor LightTeal   = new(19, 225, 190);
	public static readonly SKColor DarkBlue    = new(40, 80, 158);
	public static readonly SKColor Blue        = new(64, 147, 228);
	public static readonly SKColor Cyan        = new(96, 247, 242);
	public static readonly SKColor Indigo      = new(107, 80, 246);
	public static readonly SKColor LightIndigo = new(153, 177, 251);
	public static readonly SKColor DarkPurple  = new(120, 12, 153);
	public static readonly SKColor Purple      = new(170, 56, 185);
	public static readonly SKColor LightPurple = new(224, 159, 249);
	public static readonly SKColor DarkPink    = new(203, 0, 122);
	public static readonly SKColor Pink        = new(236, 31, 128);
	public static readonly SKColor LightPink   = new(243, 141, 169);
	public static readonly SKColor DarkBrown   = new(104, 70, 52);
	public static readonly SKColor Brown       = new(149, 104, 42);
	public static readonly SKColor Beige       = new(248, 178, 119);

	public static readonly SKColor[] AllColors = [
		Black,
		DarkGray,
		Gray,
		LightGray,
		White,
		DeepRed,
		Red,
		Orange,
		Gold,
		Yellow,
		LightYellow,
		DarkGreen,
		Green,
		LightGreen,
		DarkTeal,
		Teal,
		LightTeal,
		DarkBlue,
		Blue,
		Cyan,
		Indigo,
		LightIndigo,
		DarkPurple,
		Purple,
		LightPurple,
		DarkPink,
		Pink,
		LightPink,
		DarkBrown,
		Brown,
		Beige,
	];
}