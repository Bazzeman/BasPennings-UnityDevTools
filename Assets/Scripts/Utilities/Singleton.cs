using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static readonly object lockObject = new();
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning($"[Singleton] Instance of '{typeof(T)}' is already destroyed. Returning null.");
                return null;
            }

            lock (lockObject)
            {
                instance ??= FindObjectOfType<T>() ?? new GameObject(typeof(T).Name).AddComponent<T>();
                DontDestroyOnLoad(instance.gameObject);

                return instance;
            }
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Debug.LogWarning($"[Singleton] Another instance of {typeof(T)} already exists. Destroying this instance.");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this) applicationIsQuitting = true;
    }

    private void OnApplicationQuit() => applicationIsQuitting = true;
}
