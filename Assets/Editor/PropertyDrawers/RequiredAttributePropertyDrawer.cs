#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

/// <summary>
/// Required attribute property drawer
/// </summary>
[CustomPropertyDrawer(typeof(RequiredAttribute))]
public class RequiredAttributePropertyDrawer : PropertyDrawer
{
    private const float k_helpBoxBottomPadding = 0;
    private readonly Color k_errorColor = new(1, .2f, .2f, .1f);

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        => IsFieldSupported(property) && IsFieldEmpty(property)
            ? EditorGUIUtility.singleLineHeight * 3 + k_helpBoxBottomPadding
            : base.GetPropertyHeight(property, label);

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!IsFieldSupported(property))
        {
            Debug.LogError($"RequiredField is not supported on type of {property.propertyType}!");
            EditorGUI.PropertyField(position, property, label);
            return;
        }

        if (IsFieldEmpty(property))
        {
            RequiredAttribute requiredFieldAttribute = attribute as RequiredAttribute;

            EditorGUI.HelpBox(position, requiredFieldAttribute.Description, UnityEditor.MessageType.Error);
            EditorGUI.DrawRect(position, k_errorColor);

            position = new(
                position.x, 
                position.y + EditorGUIUtility.singleLineHeight * 2 + k_helpBoxBottomPadding, 
                position.width, 
                EditorGUIUtility.singleLineHeight);
        }

        EditorGUI.PropertyField(position, property, label);
    }

    private bool IsFieldSupported(SerializedProperty property)
        => property.propertyType == SerializedPropertyType.String || property.propertyType == SerializedPropertyType.ObjectReference;

    private bool IsFieldEmpty(SerializedProperty property)
        => property.propertyType == SerializedPropertyType.String && string.IsNullOrEmpty(property.stringValue) 
            || property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null;
}
#endif