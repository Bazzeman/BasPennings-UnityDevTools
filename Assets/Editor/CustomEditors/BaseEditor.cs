using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace BasPennings.UnityDevTools
{
    /// <summary>
    /// Base editor
    /// </summary>
    [CustomEditor(typeof(MonoBehaviour), editorForChildClasses: true)]
    public class BaseEditor : Editor
    {
        private const float k_marginTop = 10;
        private const float k_marginBottom = 20;

        private ComponentAttribute componentAttribute;
        private GUIStyle m_titleStyle;
        private Texture2D m_logo;

        private void OnEnable() => componentAttribute ??= GetComponentAttribute(target);

        public override void OnInspectorGUI()
        {
            string targetNamespace = target.GetType().Namespace;

            bool isUnityNamespace = !string.IsNullOrEmpty(targetNamespace) && targetNamespace.StartsWith("Unity");
            bool isBPNamespace = !string.IsNullOrEmpty(targetNamespace) && targetNamespace.StartsWith("BasPennings");

            if (!isUnityNamespace) HeaderGUI(componentAttribute);
            if (isBPNamespace) LogoGUI();

            base.OnInspectorGUI();
        }

        private void HeaderGUI(ComponentAttribute componentAttribute)
        {
            GUILayout.Space(k_marginTop);

            m_titleStyle ??= new(GUI.skin.label)
            {
                fontSize = 15,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter
            };

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            GUILayout.Label(componentAttribute.Name, m_titleStyle);

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            const int defaultRightMargin = 22;
            GUILayout.Box(componentAttribute.Description, GUILayout.Width(EditorGUIUtility.currentViewWidth - defaultRightMargin * 2));

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(k_marginBottom);
        }

        private void LogoGUI()
        {
            m_logo ??= AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Content/Logos/InspectorLogo.png");

            if (m_logo == null)
            {
                Debug.LogError("InspectorLogo.png could not be found in Assets/Content/Logos/.");
                return;
            }

            EditorGUILayout.BeginHorizontal();

            GUILayout.Label(m_logo);

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        private ComponentAttribute GetComponentAttribute(Object obj)
            => obj.GetType().GetCustomAttribute<ComponentAttribute>()
                ?? new ComponentAttribute(SplitCamelCase(obj.GetType().Name));

        private string SplitCamelCase(string camelCaseString) => Regex.Replace(camelCaseString, "(\\B[A-Z])", " $1");
    }

}