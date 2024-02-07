using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManagement : MonoBehaviour
{
    /// <summary>
    /// 取得時に出すエフェクト
    /// </summary>
    [SerializeField] GameObject collectEffect;


    /// <summary>
    /// 消すと同時にエフェクトをインスタンス化
    /// </summary>
    private void OnDisable()
    {
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);
    }
}
