using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    //回転量
    private Vector3 addRotate = Vector3.zero;
    private Vector3 prevE = Vector3.zero;
    //機体の修正
    private bool isCorrectionRotate = false;
    //ひとつ前のJoyconの傾き値
    private Quaternion prevGyro = Quaternion.identity;
    //トリガーボタンを押したときのJoyconの傾き値
    private Quaternion holdStartJVec = Quaternion.identity;
    //トリガーボタンを押したならtrue
    private bool hold = false;
    /// 移動速度をリジッドボディに反映
    private Rigidbody rigidbody;
    /// プレイヤーの各種速さ
    [SerializeField] private PlayerSpeed setSpeed;
    /// だんだん加速したり減速したりする
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
    /// 速さの更新
    /// </summary>
    void Update()
    {
        speed += setSpeed.accelSpeed * Time.deltaTime;
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
        var sValue = JoyconManager.Instance.j[0].GetStick();
        var x = sValue[0];
        var y = sValue[1];
        addRotate = Vector3.zero;
        if (Mathf.Abs(x) > 0.5f)
        {
            addRotate.y = x > 0 ? setSpeed.rotaSpeed : -setSpeed.rotaSpeed;
        }
        if (Mathf.Abs(y) > 0.5f)
        {
            addRotate.x = y > 0 ? setSpeed.rotaSpeed : -setSpeed.rotaSpeed;
        }
        if (addRotate.magnitude > 0.1f)
        {
            transform.Rotate(addRotate);
        }
        else
        {
            var dot = Vector3.Dot(transform.up, Vector3.up);
            isCorrectionRotate = dot < 0.9999f;
            if (isCorrectionRotate)
            {
                var targetE = -transform.eulerAngles.normalized * setSpeed.correctionRotate;
                targetE.y = 0;
                transform.Rotate(targetE);
            }
        }
        //if (JoyconManager.Instance.j[0].GetButton(Joycon.Button.SHOULDER_2))
        //{
        //    var jVec = JoyconGyroManager.gyroValue;
        //    if (hold)
        //    {
        //        var r = Vector3.Normalize(jVec.eulerAngles - holdStartJVec.eulerAngles);

        //    }
        //    //回転する
        //    else
        //    {
        //        hold = true;
        //        holdStartJVec = jVec;
        //        prevGyro = jVec;
        //        addRotate = Vector3.zero;
        //    }
        //}
        //else
        //{
        //    hold = false;
        //}
        var newVelocity = transform.forward * speed ;   
        rigidbody.velocity = newVelocity;
    }
}