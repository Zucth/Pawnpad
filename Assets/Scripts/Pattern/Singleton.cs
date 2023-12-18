using UnityEngine;
public class Singleton<T> : MonoBehaviour
    where T : Component
{

    private static T _instant;

    public static T Instance
    {
        get
        {
            if (_instant == null)
            {
                _instant = FindObjectOfType<T>();

                if (_instant == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instant = obj.AddComponent<T>();
                }
            }
            return _instant;
        }
    }

    public virtual void Awake()
    {
        if (_instant == null)
        {
            _instant = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
