using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance;

    private static bool hasDestroyed;

    private void Awake()
    {
        if (instance == null)
          instance = FindObjectOfType<T>();
        else
        {
            if (instance != this) 
                Destroy(gameObject);
        }
    }

    public static T Instance 
    { 
        get {

            if (hasDestroyed)
            {
                Debug.LogError("(SINGLETON)" + typeof(T) + " : has been destroyed but you are still trying to acces it!");
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

                }
            }

            return instance;
        }  
    }


    private void OnApplicationQuit()
    {
        hasDestroyed = true;
    }

    private void OnDestroy()
    {
        hasDestroyed = true;
    }

}

