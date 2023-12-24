using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Vector3 rotateBack = new Vector3(90,0,0);
    /// <summary>
    /// 移動速度をリジッドボディに反映
    /// </summary>
    private Rigidbody rigidbody = new Rigidbody();
    /// <summary>
    /// プレイヤーの速さ
    /// </summary>
    [SerializeField] private PlayerSpeed setSpeed;
    /// <summary>
    /// 
    /// </summary>
    private float speed;
    
    /// <summary>
    /// リジッドボディ所得
    /// </summary>
    private void Start()
    {
        rigidbody = gameObject.AddComponent<Rigidbody>();
        speed = 0;
    }
    /// <summary>
    /// 進行方向の更新
    /// </summary>
    void Update()
    {
        speed += setSpeed.accelSpeed;
        if (speed > setSpeed.maxSpeed) 
        {
            speed = setSpeed.maxSpeed;
        }
    }
    /// <summary>
    /// 進行方向に向いてその方向に移動
    /// </summary>
    private void FixedUpdate()
    {
        transform.rotation = JoyconGyroManager.gyroValue;
        transform.Rotate(rotateBack);
        rigidbody.velocity = transform.forward * speed;
    }
}