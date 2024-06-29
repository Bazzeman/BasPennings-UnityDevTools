using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Base editor
/// </summary>
[CustomEditor(typeof(MonoBehaviour), editorForChildClasses: true)]
public class BaseEditor : Editor
{

    /*  TODO
     *  - Improve this class.
     *  - Create a system that automatically changes the namespace to the project settings namespace.
     */

    static GUIStyle titleStyle = null;
    ComponentAttribute componentAttribute = null;

    private void OnEnable() => componentAttribute ??= GetComponentAttribute(target);

    public override void OnInspectorGUI()
    {
        string targetNamespace = target.GetType().Namespace;
        string rootNamespace = EditorSettings.projectGenerationRootNamespace;

        bool isUnityNamespace = !string.IsNullOrEmpty(targetNamespace) && targetNamespace.StartsWith("Unity");
        bool isRootNamespace = !string.IsNullOrEmpty(targetNamespace) && targetNamespace.Equals(rootNamespace);

        if (!isUnityNamespace && isRootNamespace) HeaderGUI(componentAttribute);

        base.OnInspectorGUI();

    }

    public static void HeaderGUI(ComponentAttribute componentAttribute)
    {
        if (componentAttribute == null) return;

        GUILayout.Space(10);

        titleStyle ??= new(GUI.skin.label)
        {
            fontSize = 15,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter
        };

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.Label(componentAttribute.Name, titleStyle);

        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.Box(componentAttribute.Description, GUILayout.Width(Screen.width * .7f));

        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(20);
    }

    public static ComponentAttribute GetComponentAttribute(Object obj)
        => obj.GetType().GetCustomAttribute<ComponentAttribute>()
            ?? new ComponentAttribute(SplitCamelCase(obj.GetType().Name));

    public static string SplitCamelCase(string camelCaseString) => Regex.Replace(camelCaseString, "(\\B[A-Z])", " $1");
}
