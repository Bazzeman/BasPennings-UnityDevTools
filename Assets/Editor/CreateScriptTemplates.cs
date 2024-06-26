using UnityEditor;

public static class CreateScriptTemplate
{
    [MenuItem("Assets/Create/Code/MonoBehaviour", priority = 40)]
    public static void CreateMonoBehaviourMenuItem()
    {
        const string templatePath = "Assets/Editor/Templates/MonoBehaviour.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScript.cs");
    }

    [MenuItem("Assets/Create/Code/Enum", priority = 41)]
    public static void CreateEnumMenuItem()
    {
        const string templatePath = "Assets/Editor/Templates/Enum.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewEnum.cs");
    }

    [MenuItem("Assets/Create/Code/Singleton", priority = 41)]
    public static void CreateSingletonMenuItem()
    {
        const string templatePath = "Assets/Editor/Templates/Singleton.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewSingleton.cs");
    }
}
