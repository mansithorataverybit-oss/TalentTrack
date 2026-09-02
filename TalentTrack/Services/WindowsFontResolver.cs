using PdfSharp.Fonts;
using System.IO;
using System;

namespace TalentTrack.Services
{
    public class WindowsFontResolver : IFontResolver
    {
        public FontResolverInfo? ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (familyName.Equals("Arial", StringComparison.OrdinalIgnoreCase))
            {
                string faceName = "Arial";
                if (isBold && isItalic) faceName = "ArialBoldItalic";
                else if (isBold) faceName = "ArialBold";
                else if (isItalic) faceName = "ArialItalic";
                return new FontResolverInfo(faceName);
            }
            return new FontResolverInfo("Arial");
        }

        public byte[]? GetFont(string faceName)
        {
            // 1. Windows standard paths
            string winFontPath = faceName switch
            {
                "ArialBold" => @"C:\Windows\Fonts\arialbd.ttf",
                "ArialItalic" => @"C:\Windows\Fonts\ariali.ttf",
                "ArialBoldItalic" => @"C:\Windows\Fonts\arialbi.ttf",
                _ => @"C:\Windows\Fonts\arial.ttf"
            };

            if (File.Exists(winFontPath))
            {
                return File.ReadAllBytes(winFontPath);
            }

            // 2. Linux standard paths (fonts-liberation, fonts-dejavu, msttcorefonts, etc.)
            string[] linuxPaths = faceName switch
            {
                "ArialBold" => new[]
                {
                    "/usr/share/fonts/truetype/liberation/LiberationSans-Bold.ttf",
                    "/usr/share/fonts/truetype/dejavu/DejaVuSans-Bold.ttf",
                    "/usr/share/fonts/truetype/msttcorefonts/arialbd.ttf",
                    "/usr/share/fonts/truetype/freefont/FreeSansBold.ttf"
                },
                "ArialItalic" => new[]
                {
                    "/usr/share/fonts/truetype/liberation/LiberationSans-Italic.ttf",
                    "/usr/share/fonts/truetype/dejavu/DejaVuSans-Oblique.ttf",
                    "/usr/share/fonts/truetype/msttcorefonts/ariali.ttf",
                    "/usr/share/fonts/truetype/freefont/FreeSansOblique.ttf"
                },
                "ArialBoldItalic" => new[]
                {
                    "/usr/share/fonts/truetype/liberation/LiberationSans-BoldItalic.ttf",
                    "/usr/share/fonts/truetype/dejavu/DejaVuSans-BoldOblique.ttf",
                    "/usr/share/fonts/truetype/msttcorefonts/arialbi.ttf",
                    "/usr/share/fonts/truetype/freefont/FreeSansBoldOblique.ttf"
                },
                _ => new[]
                {
                    "/usr/share/fonts/truetype/liberation/LiberationSans-Regular.ttf",
                    "/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf",
                    "/usr/share/fonts/truetype/msttcorefonts/arial.ttf",
                    "/usr/share/fonts/truetype/freefont/FreeSans.ttf"
                }
            };

            foreach (var path in linuxPaths)
            {
                if (File.Exists(path))
                {
                    return File.ReadAllBytes(path);
                }
            }

            // 3. Fallback: Search common Linux font directories for any matching TrueType font
            string[] searchDirs = { "/usr/share/fonts", "/usr/local/share/fonts" };
            foreach (var dir in searchDirs)
            {
                if (Directory.Exists(dir))
                {
                    var files = Directory.GetFiles(dir, "*.ttf", SearchOption.AllDirectories);
                    if (files.Length > 0)
                    {
                        return File.ReadAllBytes(files[0]);
                    }
                }
            }

            return null;
        }
    }
}
