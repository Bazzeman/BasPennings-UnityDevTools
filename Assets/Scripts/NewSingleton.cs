using UnityEngine;

namespace BasPennings.UnityDevTools
{
    /// <summary>
    /// NewSingleton
    /// </summary>
    public class NewSingleton : Singleton<NewSingleton>
    {
        // Access the instance of this class by using NewSingleton.Instance.

        // Make sure to call base.Awake() when overriding Awake method.
        // protected override void Awake() => base.Awake();
    }
}