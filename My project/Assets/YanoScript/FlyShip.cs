using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyShip : MonoBehaviour
{
    private void Start()
    {
        GameObjectPosition.AddDictionaryObject(gameObject);
    }

}