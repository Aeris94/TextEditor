using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TextEditor.Model
{
    class Edit
    {
        private static List<FontFamily> fontNames = Fonts.SystemFontFamilies.OrderBy(f => f.Source).ToList();
        private static List<double> fontSize = new List<double> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };


        public static List<FontFamily> FontNames
        {
            get { return fontNames; }
        }

        public static List<double> FontSize
        {
            get { return fontSize; }
        }

    }
}
