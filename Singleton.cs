using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance;

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

            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    instance = go.AddComponent<T>();

                    go.name = typeof(T) + "_SINGLETON";

                    DontDestroyOnLoad(instance);

                }
            }

            return instance;
        }  
    }

}
