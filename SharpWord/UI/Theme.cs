using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SharpWord.UI 
{
    public class Theme
    {

        public Color TileNotExistBackColor;
        public Color TileNotExistForeColor;
        public Color TileNotCorrectPositionBackColor;
        public Color TileNotCorrectPositionForeColor;
        public Color TileCorrectBackColor;
        public Color TileCorrectForeColor;
        public Color TileNormalBackColor;
        public Color TileNormalForeColor;

        public Color LabelAnswerForeColor;
        public Color LabelAnswerBackColor;
        public Color BoardBackColor;
        public Color BoardForeColor;
        public Color KeyBackColor;
        public Color KeyForeColor;
        public Color ButtonBackColor;
        public Color ButtonForeColor;

        public Color PopupFormBackColor;
        private static Theme _CurrentTheme;
     
        public static Theme CurrentTheme()
        {
            if(_CurrentTheme ==null)
            {
                _CurrentTheme = new Theme();
               // _CurrentTheme.
            }
            return _CurrentTheme;
        }

        public Boolean IsFormCaptionDarkMode { get; set; } = true;
    }

}
