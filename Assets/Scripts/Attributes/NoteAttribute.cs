using UnityEngine;

/// <summary>
/// Note attribute
/// </summary>
public class NoteAttribute : PropertyAttribute
{
    public string Text = string.Empty;
    public MessageType messageType = MessageType.None;

    public NoteAttribute(string text) => Text = text;
}
