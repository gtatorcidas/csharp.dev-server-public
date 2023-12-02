using SampSharp.Entities.SAMP;

namespace Torcidas.Core.Utils
{
    public struct CustomColorsUtils
    {
        public static Color Yellow { get; } = Color.FromString("FFC436", ColorFormat.RGB);
        public static Color White { get; } = Color.FromString("FFFFFF", ColorFormat.RGB);
        
        public static Color WhiteTransparent { get; } = Color.FromString("FFFFFF10", ColorFormat.RGBA);
        public static Color LimeGreen { get; } = Color.FromString("00FF00", ColorFormat.RGB);
        public static Color RedScore { get; } = Color.FromString("F50000", ColorFormat.RGB);
        public static Color RedWhite { get; } = Color.FromString("E44235", ColorFormat.RGB);
        public static Color SilverGray { get; } = Color.FromString("B5B5B5", ColorFormat.RGB);
        public static Color DeepSkyBlue { get; } = Color.FromString("00BFFF", ColorFormat.RGB);
        public static Color PaleGoldenrod { get; } = Color.FromString("00BFFF", ColorFormat.RGB);
        public static Color DarkOrange { get; } = Color.FromString("FF8C00", ColorFormat.RGB);

    }
}
