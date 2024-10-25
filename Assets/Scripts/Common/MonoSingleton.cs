using UnityEngine;

[DefaultExecutionOrder(10000)]
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static object lockObject = new object();
    private static bool isCreate = false;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    instance = Transform.FindObjectOfType<T>();
                    if(instance == null)
                    {
                        var name = typeof(T).Name;
                        var prefab = Resources.Load<GameObject>($"instance/{name}");
                        if(prefab != null)
                        {
                            var go = GameObject.Instantiate(prefab);
                            instance = go.GetComponent<T>();
                        }
                        if (instance == null)
                        {
                            var go = new GameObject(typeof(T).Name);
                            GameObject.DontDestroyOnLoad(go);
                            instance = go.AddComponent<T>();
                        }
                    }
                }
                if(instance.transform.parent == null)
                {
                    GameObject.DontDestroyOnLoad(instance.gameObject);
                }
                (instance as MonoSingleton<T>).Initialize();
                isCreate = true;
            }
            return instance;
        }
    }

    public static bool IsCreate => isCreate;

    protected virtual void Initialize()
    {

    }
}