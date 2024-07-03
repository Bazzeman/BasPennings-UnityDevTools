using System;
using UnityEngine;

namespace BasPennings.UnityDevTools
{
    /// <summary>
    /// Note attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class NoteAttribute : PropertyAttribute
    {
        public string Text = string.Empty;
        public MessageType messageType = MessageType.None;

        public NoteAttribute(string text) => Text = text;
    }

    /// <summary>
    /// User message types
    /// </summary>
    public enum MessageType
    {
        //
        // Summary:
        //     Neutral message.
        None,
        //
        // Summary:
        //     Info message.
        Info,
        //
        // Summary:
        //     Warning message.
        Warning,
        //
        // Summary:
        //     Error message.
        Error
    }
}

