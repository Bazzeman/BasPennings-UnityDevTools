using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class OpenFolderTool
{
    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceId)
    {
        if (!Event.current.shift) return false;

        Object obj = EditorUtility.InstanceIDToObject(instanceId);
        string path = AssetDatabase.GetAssetPath(obj);

        EditorUtility.RevealInFinder(path);
        return true;
    }
}
