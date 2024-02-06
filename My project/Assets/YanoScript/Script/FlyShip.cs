using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// プレイヤーの位置が分かるようにする
/// </summary>
public class FlyShip : MonoBehaviour
{
    /// <summary>
    /// 位置を伝える
    /// </summary>
    void Start()
    {
        GameObjectPosition.AddDictionaryObject(gameObject);
    }

}