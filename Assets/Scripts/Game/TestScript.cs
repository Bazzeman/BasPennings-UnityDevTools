using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// TestScript
/// </summary>
public class TestScript : MonoBehaviour
{
    [Note("This is a very important note, because it is noted!", messageType = MessageType.Warning)]

    [Required][SerializeField] private string description;
}