using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(NoteAttribute))]
public class NoteAttributeDecoratorDrawer : DecoratorDrawer
{
    const float padding = 20;
    private float height;

    GUIStyle style = null;

    public override float GetHeight()
    {
        NoteAttribute noteAttribute = attribute as NoteAttribute;

        style ??= new(EditorStyles.helpBox)
        {
            alignment = TextAnchor.MiddleLeft,
            wordWrap = true,
            padding = new RectOffset(10, 10, 10, 10),
            fontSize = 12
        };

        height = style.CalcHeight(new GUIContent(noteAttribute.Text), EditorGUIUtility.currentViewWidth - 20);

        return height + padding * 2;
    }

    public override void OnGUI(Rect position)
    {
        NoteAttribute noteAttribute = attribute as NoteAttribute;

        position.y += padding;
        position.height = height;
        EditorGUI.HelpBox(position, noteAttribute.Text, (UnityEditor.MessageType)noteAttribute.messageType);
    }
}
