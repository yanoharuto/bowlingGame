using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyShip : MonoBehaviour
{
    /// <summary>
    /// �ʒu��`����
    /// </summary>
    void Start()
    {
        GameObjectPosition.AddDictionaryObject(gameObject);
    }

}