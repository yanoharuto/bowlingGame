using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyShip : MonoBehaviour
{
    private 
    /// <summary>
    /// 位置を伝える
    /// </summary>
    private void Start()
    {
        GameObjectPosition.AddDictionaryObject(gameObject);
    }

}