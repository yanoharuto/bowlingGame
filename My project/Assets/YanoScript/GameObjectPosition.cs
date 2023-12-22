using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPosition
{
    private static Dictionary<string,GameObject> tagObject= new Dictionary<string,GameObject>();

    public static void AddDictionaryObject(GameObject gameObject)
    {
        if (!tagObject.ContainsKey(gameObject.tag))
        {
            tagObject.Add(gameObject.tag, gameObject);
        }
    }

    public static void DeleteDictionaryObject(GameObject gameObject)
    {
        if (tagObject.ContainsKey(gameObject.tag) && tagObject[gameObject.tag] == gameObject) 
        {
            tagObject.Remove(gameObject.tag);
        }
    }

    public static Vector3 GetDictionaryObjectPositon(string tagName)
    {
        return tagObject[tagName].transform.position;
    }

    public static Vector3 GetDictionaryObjectForward(string tagName)
    {
        return tagObject[tagName].transform.forward;
    }
}
