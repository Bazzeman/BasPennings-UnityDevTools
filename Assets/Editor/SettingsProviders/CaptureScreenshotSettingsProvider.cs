using UnityEditor;
using UnityEngine;

namespace BasPennings.UnityDevTools
{
    /// <summary>
    /// Capture screenshot settings provider
    /// </summary>
    public class CaptureScreenshotSettingsProvider : SettingsProvider
    {
        public CaptureScreenshotSettingsProvider(string path, SettingsScope scope = SettingsScope.User) : base(path, scope)
        {

        }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);

            GUILayout.Space(20);

            string path = EditorPrefs.GetString(CaptureScreenshotTool.k_editorPrefs); 
        
            if (string.IsNullOrWhiteSpace(path)) 
                path = CaptureScreenshotTool.GetDefaultPath();

            string changedPath = EditorGUILayout.TextField(path);
            if (string.Compare(path, changedPath) != 0)
                EditorPrefs.SetString(CaptureScreenshotTool.k_editorPrefs, changedPath);

            GUILayout.Space(10);

            if(GUILayout.Button("Reset to Default", GUILayout.Width(150)))
            {
                EditorPrefs.DeleteKey(CaptureScreenshotTool.k_editorPrefs);
                Repaint();
            }
        }

        [SettingsProvider]
        public static SettingsProvider CreateCaptureScreenshotSettingsProvider()
            => new CaptureScreenshotSettingsProvider(CaptureScreenshotTool.k_menuPath);
    }
}