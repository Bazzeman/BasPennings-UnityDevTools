#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// CreateScriptTemplate script adds custom menu items to the Unity Editor for creating new script files from templates.
/// It allows users to create MonoBehaviour, Enum, and Singleton script files from pre-defined templates located in the Assets/Editor/Templates folder.
/// </summary>
public static class CreateScriptTemplate
{
    [MenuItem("Assets/Create/Code/MonoBehaviour", priority = 40)]
    public static void CreateMonoBehaviourMenuItem()
    {
        const string templatePath = "Assets/Editor/ScriptTemplates/MonoBehaviour.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScript.cs");
    }

    [MenuItem("Assets/Create/Code/Singleton", priority = 41)]
    public static void CreateSingletonMenuItem()
    {
        const string templatePath = "Assets/Editor/ScriptTemplates/Singleton.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewSingleton.cs");
    }

    [MenuItem("Assets/Create/Code/Enum", priority = 41)]
    public static void CreateEnumMenuItem()
    {
        const string templatePath = "Assets/Editor/ScriptTemplates/Enum.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewEnum.cs");
    }

    [MenuItem("Assets/Create/Code/Struct", priority = 41)]
    public static void CreateStructMenuItem()
    {
        const string templatePath = "Assets/Editor/ScriptTemplates/Struct.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewStruct.cs");
    }
}
#endif
