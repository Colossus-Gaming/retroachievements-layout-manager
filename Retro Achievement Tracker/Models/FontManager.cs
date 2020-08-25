using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace Retro_Achievement_Tracker.Models
{
    public class FontManager
    {
        private static PrivateFontCollection _privateFontCollection;
        private FontManager()
        {
            
        }

        public static FontFamily GetFontFamilyByName(string name)
        {
            if (_privateFontCollection == null)
            {
                _privateFontCollection = new PrivateFontCollection();
                AddFonts();
            }
            return _privateFontCollection.Families.FirstOrDefault(x => x.Name == name);
        }

        private static void AddFonts()
        {
            _privateFontCollection.AddFontFile(@"Resources\monofonto.ttf");
            _privateFontCollection.AddFontFile(@"Resources\EightBitDragon-anqx.ttf");
        }
    }
}
