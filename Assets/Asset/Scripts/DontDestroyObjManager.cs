using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjManager : MonoBehaviour {
    static public List<GameObject> dontDestroyObjects = new List<GameObject>();
    
    static public void DontDestroyOnLoad(GameObject obj)
    {
        Object.DontDestroyOnLoad(obj);
        dontDestroyObjects.Add(obj);
    }
    
    static public void DestroyAll()
    {
        foreach(GameObject obj in dontDestroyObjects)
        {
            Destroy(obj);
        }
        dontDestroyObjects.Clear();
    }
}