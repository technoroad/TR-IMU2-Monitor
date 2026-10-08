using System;
using System.Drawing;
using System.Globalization;


namespace IMU_PlatformTool2.Services
{
    public static class ImageResourceHelper
    {
        /// <summary>
        /// Resources.resx から、指定名の画像を Image として取得する。
        /// 画像が無い/型が違う場合は null を返す（例外にしたいならthrowに変更）。
        /// </summary>
        public static Image GetImageFromResx(string resourceName)
        {
            if (string.IsNullOrWhiteSpace(resourceName))
                return null;

            // Properties.Resources.ResourceManager を使うと文字列名で取れる
            object obj = Properties.Resources.ResourceManager.GetObject(resourceName, CultureInfo.CurrentUICulture);

            // Bitmap も Image の派生なので、Imageとして返せる
            return obj as Image;
        }
    }
}