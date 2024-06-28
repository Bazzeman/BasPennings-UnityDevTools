using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(NoteAttribute))]
public class NoteAttributeDecoratorDrawer : DecoratorDrawer
{
    const float padding = 20;
    private float height = 0;

    public override float GetHeight()
    {
        NoteAttribute noteAttribute = attribute as NoteAttribute;

        GUIStyle style = EditorStyles.helpBox;
        style.alignment = TextAnchor.MiddleLeft;
        style.wordWrap = true;
        style.padding = new RectOffset(10, 10, 10, 10);
        style.fontSize = 12;

        height = style.CalcHeight(new GUIContent(noteAttribute.Text), EditorGUIUtility.currentViewWidth);

        return height + padding;
    }

    public override void OnGUI(Rect position)
    {
        NoteAttribute noteAttribute = attribute as NoteAttribute;

        position.height = height;
        position.y += padding / 2;
        EditorGUI.HelpBox(position, noteAttribute.Text, (UnityEditor.MessageType)noteAttribute.messageType);
    }
}