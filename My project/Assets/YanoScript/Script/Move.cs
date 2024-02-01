using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Move : MonoBehaviour
{ 
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
        var isL = JoyconManager.Instance.j[0].isLeft;
        var lCon = isL ? JoyconManager.Instance.j[0] : JoyconManager.Instance.j[1];
        var rCon = isL ? JoyconManager.Instance.j[1] : JoyconManager.Instance.j[0];
        //ジョイコンのスティックの値
        var sValue = lCon.GetStick();
        var horizon = sValue[0];
        var vertical = sValue[1];
        var addRotate = Vector3.zero;
        
        var isPushLShoulder1 = lCon.GetButton(Joycon.Button.SHOULDER_1);

        if (Mathf.Abs(horizon) > 0.5f)
        {
            addRotate.z = horizon > 0 ? -setSpeed.rotaSpeed : setSpeed.rotaSpeed;
        }
        if (Mathf.Abs(vertical) > 0.5f)
        {
            addRotate.x = vertical > 0 ? setSpeed.rotaSpeed : -setSpeed.rotaSpeed;
        }
        if (isPushLShoulder1|| rCon.GetButton(Joycon.Button.SHOULDER_1))
        {
            addRotate.y = isPushLShoulder1 ? -setSpeed.rotaSpeed : setSpeed.rotaSpeed;
        }
        if (addRotate.magnitude > 0.1f)
        {
            transform.Rotate(addRotate);
        }
        var newVelocity = transform.forward * speed ;   
        rigidbody.velocity = newVelocity;
    }
}