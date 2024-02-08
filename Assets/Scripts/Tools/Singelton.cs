using UnityEngine;

public class Singelton <T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            else
            {
                var instances = GameObject.FindObjectsOfType<T>();
                var count = instances.Length;
                if (count > 0)
                {
                    if (count == 1)
                        return _instance = instances[0];
                    for (int i = 1; i < count; i++)
                        Destroy(instances[i]);
                    return _instance = instances[0];
                }
                Debug.Log($"Объекта типа {typeof(T)} нет сцене");
                return _instance = null;
            }
        }
        private set => Instance = value;
    }
}
