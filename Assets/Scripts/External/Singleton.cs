using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;

    private static bool _isQuitting = false;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    Debug.LogWarning("There is more than one manager of this type in this scene : " + typeof(T).Name);
                    return _instance;
                }

                if (_instance == null && !_isQuitting) return null;
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
    }

    public static void SetActive(bool _Active)
    {
        Instance.gameObject.SetActive(_Active);
    }

    void OnDestroy()
    {
        OnDestroySpecific();
    }

    public virtual void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    protected virtual void OnDestroySpecific() { }
}