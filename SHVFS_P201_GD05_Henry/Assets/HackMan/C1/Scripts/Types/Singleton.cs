using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance != null) return instance;
            instance = FindObjectOfType<T>();

            if (instance == null)
            {
                instance = new GameObject(typeof(T).Name).AddComponent<T>();
            }
            
            DontDestroyOnLoad(instance.gameObject);
            return instance;
        }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = (T) this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
