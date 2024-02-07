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
    [SerializeField] Move move;
    enum GameFase
    {
        start,
        play,
        end,
    }
    public bool isAlive { get; private set; } = true;
    
    /// <summary>
    /// �ʒu��`����
    /// </summary>
    void Start()
    {
        GameObjectPosition.AddDictionaryObject(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Obstacle")
        {
            isAlive = false;
            move.enabled= false;
        }
    }
}