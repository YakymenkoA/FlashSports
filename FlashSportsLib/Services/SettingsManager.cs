using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Services
{
    public class SettingsManager
    {
        // Same path for everything
        private readonly string _regPath = Registry.CurrentUser.Name;
        private readonly string _key = "FlashSports";

        public void SaveFontSizeSetting(float fontSize)
        {
            Registry.SetValue(_regPath + "\\" + _key, "FontSize", fontSize);
        }

        public float ReadFontSizeSetting()
        {
            var reg = Registry.CurrentUser.OpenSubKey(_key);
            if (reg != null)
                return float.Parse(reg.GetValue("FontSize").ToString());
            else
                return (float)9.75;
        }

        public void SaveFontFamilySetting(string fontFamily)
        {
            Registry.SetValue(_regPath, "FontFamily", fontFamily);
        }

        public string ReadFontFamilySetting()
        {
            // Open data
            var reg = Registry.GetValue(_regPath, "FontFamily", null);

            if (reg != null)
                return reg.ToString();
            else
                return "Microsoft Sans Serif"; // Def
        }

        public void SaveBackColorSetting(string backColor)
        {
            Registry.SetValue(_regPath, "BackColor", backColor);
        }

        public string ReadBackColorSetting()
        {
            // Open data
            var reg = Registry.GetValue(_regPath, "BackColor", null);

            if (reg != null)
                return reg.ToString();
            else
                return "Control"; // Def
        }
    }
}
