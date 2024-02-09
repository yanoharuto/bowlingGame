using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �e�^�O�̃I�u�W�F�N�g�̈ʒu�ƌ�����`����
/// </summary>
public class GameObjectPosition
{
    private static Dictionary<string,GameObject> tagObject= new Dictionary<string,GameObject>();
    /// <summary>
    /// �����̃I�u�W�F�N�g��o�^
    /// </summary>
    /// <param name="gameObject"></param>
    public static void AddDictionaryObject(GameObject gameObject)
    {
        if (!tagObject.ContainsKey(gameObject.tag))//�������łɓ����Ă���Ȃ�ǉ��ł��Ȃ�
        {
            tagObject.Add(gameObject.tag, gameObject);
        }
        else
        {
            tagObject[gameObject.tag] = gameObject;
        }
    }
    /// <summary>
    /// �����̃I�u�W�F�N�g���폜
    /// </summary>
    /// <param name="gameObject"></param>
    public static void DeleteDictionaryObject(GameObject gameObject)
    {
        if (tagObject.ContainsKey(gameObject.tag) && tagObject[gameObject.tag] == gameObject) //�폜�ł���Ȃ�
        {
            tagObject.Remove(gameObject.tag);
        }
    }
    /// <summary>
    /// �����̃^�O�̃I�u�W�F�N�g�̈ʒu
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
    /// �����̃^�O�̃I�u�W�F�N�g�̌���
    /// </summary>
    /// <param name="tagName"></param>
    /// <returns></returns>
    public static Vector3 GetDictionaryObjectForward(string tagName)
    {
        return tagObject[tagName].transform.forward;
    }
}
