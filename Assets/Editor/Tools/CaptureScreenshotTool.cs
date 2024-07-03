using UnityEngine;
using UnityEditor;
using System.IO;
using System;

namespace BasPennings.UnityDevTools
{
    /// <summary>
    /// Capture sreenshot tool
    /// </summary>
    public static class CaptureScreenshotTool
    {
        public const string k_editorPrefs = "CaptureScreenshotPath";
        public const string k_menuPath = "BP Dev Tools/Capture Screenshot";

        [MenuItem(k_menuPath + " _F11")]
        public static void CaptureScreenshotToolMenuItem()
        {
            string path = EditorPrefs.GetString(k_editorPrefs);
            if (string.IsNullOrWhiteSpace(path))
                path = GetDefaultPath();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = Path.Combine(path, $"{Application.productName}_{DateTime.Now:yyyyMMddHHmmss}.jpg");
        
            ScreenCapture.CaptureScreenshot(filePath, 1);

            Debug.Log($"Screenshot saved to: {filePath} \n Make sure to have the Game view open when capturing screenshots!");
        }

        public static string GetDefaultPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Screenshots");
    }
}