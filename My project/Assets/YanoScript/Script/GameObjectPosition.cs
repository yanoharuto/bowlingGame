using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 各タグのオブジェクトの位置と向きを伝える
/// </summary>
public class GameObjectPosition
{
    private static Dictionary<string,GameObject> tagObject= new Dictionary<string,GameObject>();
    /// <summary>
    /// 引数のオブジェクトを登録
    /// </summary>
    /// <param name="gameObject"></param>
    public static void AddDictionaryObject(GameObject gameObject)
    {
        if (!tagObject.ContainsKey(gameObject.tag))//もうすでに入っているなら追加できない
        {
            tagObject.Add(gameObject.tag, gameObject);
        }
        else
        {
            tagObject[gameObject.tag] = gameObject;
        }
    }
    /// <summary>
    /// 引数のオブジェクトを削除
    /// </summary>
    /// <param name="gameObject"></param>
    public static void DeleteDictionaryObject(GameObject gameObject)
    {
        if (tagObject.ContainsKey(gameObject.tag) && tagObject[gameObject.tag] == gameObject) //削除できるなら
        {
            tagObject.Remove(gameObject.tag);
        }
    }
    /// <summary>
    /// 引数のタグのオブジェクトの位置
    /// </summary>
    /// <param name="tagName"></param>
    /// <returns></returns>
    public static Vector3 GetDictionaryObjectPositon(string tagName)
    {
        return tagObject[tagName].transform.position;
    }
    public static bool IsContain(string tag)
    {
        return tagObject.ContainsKey(tag);
    }
    /// <summary>
    /// 引数のタグのオブジェクトの向き
    /// </summary>
    /// <param name="tagName"></param>
    /// <returns></returns>
    public static Vector3 GetDictionaryObjectForward(string tagName)
    {
        return tagObject[tagName].transform.forward;
    }
}
