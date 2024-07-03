#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(NoteAttribute))]
public class NoteAttributeDecoratorDrawer : DecoratorDrawer
{
    private const float k_verticalMargin = 18;
    private const int k_horizontalPadding = 9;
    private const int k_verticalPadding = 9;

    private NoteAttribute m_attribute;
    private GUIStyle m_style;

    public override float GetHeight()
    {
        m_attribute ??= attribute as NoteAttribute;

        m_style ??= new GUIStyle(EditorStyles.helpBox)
        {
            alignment = TextAnchor.MiddleLeft,
            wordWrap = true,
            padding = new(k_horizontalPadding, k_horizontalPadding, k_verticalPadding, k_verticalPadding),
            fontSize = 12
        };

        const int defaultRightPadding = 22; // (in OnGUI log EditorGUIUtility.currentViewWidth - position.width)
        float contentHeight = m_style.CalcHeight(new GUIContent(m_attribute.Text), EditorGUIUtility.currentViewWidth - defaultRightPadding);

        return contentHeight + k_verticalMargin * 2;
    }

    public override void OnGUI(Rect position)
    {
        Texture2D icon = GetIcon(m_attribute.messageType);
        GUIContent content = icon != null ? new (m_attribute.Text, icon) : new(m_attribute.Text);

        position = new(
            position.x,
            position.y + k_verticalMargin,
            position.width,
            position.height - k_verticalMargin * 2);

        EditorGUI.LabelField(position, content, m_style);
    }

    private Texture2D GetIcon(MessageType messageType)
    {
        string iconName = messageType switch
        {
            MessageType.Error => "console.erroricon",
            MessageType.Warning => "console.warnicon",
            MessageType.Info => "console.infoicon",
            _ => null
        };

        return iconName != null ? EditorGUIUtility.IconContent(iconName).image as Texture2D : null;
    }
}
#endif