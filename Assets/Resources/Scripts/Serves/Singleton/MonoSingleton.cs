using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    public static bool applicationIsQuitting = false;
    
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (!_instance)
            {
                if (applicationIsQuitting) {
                    return _instance;           //如果销毁了则直接返回，不能再创建
                }
                _instance = FindAnyObjectByType<T>();
                if (!_instance)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    protected virtual void OnDestroy() {
        applicationIsQuitting = true;
    }
}
