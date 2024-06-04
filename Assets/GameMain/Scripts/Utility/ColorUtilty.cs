using UnityEngine;

namespace GFLearning
{
    public static class ColorUtilty
    {
        // 静态方法，用于将16进制字符串转换为Color对象
        public static Color HexToColor(string hex)
        {
            hex = hex.Replace("0x", ""); // 允许0x前缀
            hex = hex.Replace("#", "");  // 允许#前缀

            if (hex.Length != 6 && hex.Length != 8)
            {
                Debug.LogError("无效的十六进制颜色长度,必须为6个(RGB)或8个(RGBA)字符");
                return Color.red;
            }

            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            byte a = 255; // 默认透明度为255

            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            }

            return new Color32(r, g, b, a);
        }
    }
}
