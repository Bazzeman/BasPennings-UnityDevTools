using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RequiredAttribute))]
public class RequiredAttributePropertyDrawer : PropertyDrawer
{
    readonly Color errorColor = new Color(1, .2f, .2f, .1f);

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float baseHeight = base.GetPropertyHeight(property, label);

        if (IsFieldEmpty(property))
        {
            return baseHeight + EditorGUIUtility.singleLineHeight;
        }

        return baseHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!IsFieldSupported(property))
        {
            Debug.LogError("Required Attribute placed on incompatible field type");
            return;
        }

        Rect basePosition = new Rect(position.x, position.y, position.width, base.GetPropertyHeight(property, label));

        if (IsFieldEmpty(property))
        {
            Rect helpBoxPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight * 3);
            Rect rectPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight * 3);
            EditorGUI.HelpBox(helpBoxPosition, "Required", UnityEditor.MessageType.Error);
            EditorGUI.DrawRect(rectPosition, errorColor);

            basePosition.y += EditorGUIUtility.singleLineHeight * 2;
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
        }

        EditorGUI.PropertyField(basePosition, property, label);
    }

    private bool IsFieldEmpty(SerializedProperty property)
    {
        if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null)
            return true;

        if (property.propertyType == SerializedPropertyType.String && string.IsNullOrEmpty(property.stringValue))
            return true;

        return false;
    }

    private bool IsFieldSupported(SerializedProperty property) => 
        property.propertyType == SerializedPropertyType.ObjectReference || property.propertyType == SerializedPropertyType.String;
}
