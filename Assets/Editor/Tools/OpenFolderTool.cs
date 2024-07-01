using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

/// <summary>
/// OpenFolderTool script adds functionality to the Unity Editor to open folders in the system file explorer.
/// When a file is double-clicked in the Project window while holding the Shift key,
/// it opens the folder in the system file explorer where the file is located in.
/// </summary>
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
