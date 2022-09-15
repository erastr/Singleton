using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance;

    private static bool isDestroyed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();

            DontDestroyOnLoad(instance);
        }
        else
        {
            if (instance != this) 
                Destroy(gameObject);
        }
    }

    public static T Instance 
    { 
        get {

            if (isDestroyed)
            {
                Debug.LogError("(SINGLETON)" + typeof(T) + " : has been destroyed but you have still try to use!");
                return null;
            }

            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    instance = go.AddComponent<T>();

                    go.name = typeof(T).ToString() + "_SINGLETON_CREATED";

                    DontDestroyOnLoad(instance);

                }
            }

            return instance;
        }  
    }


    private void OnApplicationQuit()
    {
        isDestroyed = true;
    }

    private void OnDestroy()
    {
        isDestroyed = true;
    }

}
