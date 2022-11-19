using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWord.Game
{
    [Serializable]
    public class SharpWordSettings
    {
        public Boolean IsUsingDarkTheme { get; set; }
        public Boolean IsUsingSmallScreen { get; set; }

    }
}
