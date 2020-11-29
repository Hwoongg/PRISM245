using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    static GameObject container;
    

    static public T Instance()
    {
        if(instance == null)
        {
            container = new GameObject();
            instance = container.AddComponent<T>();
        }

        return instance;
    }

    virtual public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        System.Type ty = GetType();
        gameObject.name = ty.ToString();
    }
}
