using UnityEngine;

namespace GFLearning
{
    public static class ColorUtilty
    {
        // ��̬���������ڽ�16�����ַ���ת��ΪColor����
        public static Color HexToColor(string hex)
        {
            hex = hex.Replace("0x", ""); // ����0xǰ׺
            hex = hex.Replace("#", "");  // ����#ǰ׺

            if (hex.Length != 6 && hex.Length != 8)
            {
                Debug.LogError("��Ч��ʮ��������ɫ����,����Ϊ6��(RGB)��8��(RGBA)�ַ�");
                return Color.red;
            }

            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            byte a = 255; // Ĭ��͸����Ϊ255

            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            }

            return new Color32(r, g, b, a);
        }
    }
}
