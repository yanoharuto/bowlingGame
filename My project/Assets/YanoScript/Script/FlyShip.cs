using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// �v���C���[�̈ʒu��������悤�ɂ���
/// </summary>
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