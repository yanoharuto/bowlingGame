using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private const float GYRO_MIN_VALUE = 12;
    private Rigidbody rigidbody = new Rigidbody();
    private const float MOVE_POINT_BETWEEN = 50.0f;
    private Vector3 movePoint = new Vector3();
    /// <summary>
    /// リジッドボディ所得
    /// </summary>
    private void Start()
    {
        movePoint = transform.position + transform.forward * MOVE_POINT_BETWEEN;
        rigidbody = gameObject.AddComponent<Rigidbody>();
    }
    /// <summary>
    /// 進行方向の更新
    /// </summary>
    void Update()
    {
        movePoint = transform.position + transform.forward * MOVE_POINT_BETWEEN;
        var addEuler = JoyconGyroManager.eulerAngleAddValue;

        if (addEuler.y < -GYRO_MIN_VALUE)
        {
            movePoint -= transform.right;
        }
        else if (addEuler.y > GYRO_MIN_VALUE) 
        {
            movePoint += transform.right;
        }
        if (addEuler.x < -GYRO_MIN_VALUE) 
        {
            movePoint -= transform.up;
        }
        else if (addEuler.x > GYRO_MIN_VALUE) 
        {
            movePoint += transform.up;
        }
    }
    /// <summary>
    /// 進行方向に向いてその方向に移動
    /// </summary>
    private void FixedUpdate()
    {
        transform.LookAt(movePoint,Vector3.up);
        rigidbody.velocity = transform.forward * 10.0f;
    }
}
