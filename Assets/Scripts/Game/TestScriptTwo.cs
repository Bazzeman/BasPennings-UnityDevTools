using UnityEngine;

namespace BasPennings.UnityDevTools
{
    /// <summary>
    /// TestScriptTwo
    /// </summary>
    [Component("Test Script", "A script for testing features such as attributes, templates or utilities.")]
    public class TestScriptTwo : MonoBehaviour {
        [SerializeField] private string name;

        [Required]
        [SerializeField] private string description;

        [Note("This is a very important note, because it is noted! That means that you should read this", messageType = MessageType.Warning)]

        [SerializeField] private int health;
    }
}