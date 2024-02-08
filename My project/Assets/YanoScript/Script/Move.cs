using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
/// <summary>
/// 移動用
/// </summary>
public class Move : MonoBehaviour
{
    //トリガーボタンを押したときのJoyconの傾き値
    private Quaternion holdStartJVec = Quaternion.identity;
    //トリガーボタンを押したならtrue
    private bool hold = false;
    /// 移動速度をリジッドボディに反映
    private Rigidbody rBody;
    /// プレイヤーの各種速さ
    [SerializeField] private PlayerSpeed setSpeed;
    /// だんだん加速したり減速したりする
    private float speed;
    private float brekePower;
    private float rotaSpeedX;
    private float rotaSpeedY;
    private float rotaSpeedZ;

    /// <summary>
    /// 加速ボタンが押されているか
    /// </summary>
    bool m_buttonAccel = false;


    /// <summary>
    /// リジッドボディ所得
    /// </summary>
    private void Start()
    {
        rBody = gameObject.AddComponent<Rigidbody>();
        speed = setSpeed.minSpeed;
    }
    /// <summary>
    /// 速さの更新
    /// </summary>
    void Update()
    {
        if (JoyconInput.GetRButtonFase(Joycon.Button.DPAD_DOWN) == JoyconInput.InputFase.hold)
        {
            brekePower += setSpeed.decelSpeed * Time.deltaTime;
            speed -= brekePower;
            if(speed < setSpeed.minSpeed)
            {
                speed = setSpeed.minSpeed;
            }
            if(brekePower > setSpeed.maxBreakPow)
            {
                brekePower = setSpeed.maxBreakPow;
            }
        }
        else
        {
            brekePower = Mathf.Lerp(brekePower, 0, Time.deltaTime);
            if (JoyconInput.GetRButtonFase(Joycon.Button.DPAD_RIGHT) == JoyconInput.InputFase.hold)
            {
                m_buttonAccel = true;
                speed += setSpeed.accelSpeed * setSpeed.boostRaito * Time.deltaTime;
            }
            else
            {
                m_buttonAccel= false;
                speed += setSpeed.accelSpeed * Time.deltaTime;
            }
            if (speed > setSpeed.maxSpeed)
            {
                speed = setSpeed.maxSpeed;
            }
        }
    }
    /// <summary>
    /// 進行方向に向いてその方向に移動
    /// </summary>
    private void FixedUpdate()
    {
        //ジョイコンのスティックの値
        var sValue = JoyconInput.lJ.GetStick();
        var horizon = sValue[0];
        var vertical = sValue[1];
        var addRotate = Vector3.zero;
        if (Mathf.Abs(horizon) > 0.5f)
        {
            addRotate.z = setSpeed.rotaSpeed.z * rotaSpeedZ;

            rotaSpeedZ += (horizon > 0 ? -setSpeed.rotaAccelSpeed : setSpeed.rotaAccelSpeed) * Time.deltaTime;
            
            rotaSpeedZ = rotaSpeedZ > setSpeed.rotaMaxSpeed ? (rotaSpeedZ > 0 ? 1 : -1) * setSpeed.rotaMaxSpeed : rotaSpeedZ;
        }
        else if(Mathf.Abs(rotaSpeedZ) > 0.0001f)
        {
            rotaSpeedZ = Mathf.Lerp(rotaSpeedZ, 0, setSpeed.rotaDeccelSpeed);
            addRotate.z = setSpeed.rotaSpeed.z * rotaSpeedZ;
        }
        else
        {
            rotaSpeedZ = 0;
        }
        if (Mathf.Abs(vertical) > 0.5f)
        {
            addRotate.x = setSpeed.rotaSpeed.x * rotaSpeedX;
            rotaSpeedX += (vertical > 0 ? setSpeed.rotaAccelSpeed : -setSpeed.rotaAccelSpeed) * Time.deltaTime;
            rotaSpeedX = Mathf.Abs(rotaSpeedX) > setSpeed.rotaMaxSpeed ? (rotaSpeedZ > 0 ? 1 : -1) * setSpeed.rotaMaxSpeed : rotaSpeedX;
        }
        else if(Mathf.Abs(rotaSpeedX) > 0.0001f)
        {
            rotaSpeedX = Mathf.Lerp(rotaSpeedX, 0, setSpeed.rotaDeccelSpeed);
            addRotate.x = setSpeed.rotaSpeed.x * rotaSpeedX;
        }
        else
        {
            rotaSpeedX = 0;
        }

        if (JoyconInput.GetLButtonFase(Joycon.Button.SHOULDER_1) == JoyconInput.InputFase.hold)
        {
            addRotate.y = setSpeed.rotaSpeed.y * rotaSpeedY;
            rotaSpeedY -= setSpeed.rotaAccelSpeed * Time.deltaTime;
            rotaSpeedY = rotaSpeedY < -setSpeed.rotaMaxSpeed ? -setSpeed.rotaMaxSpeed : rotaSpeedY;
        }
        else if (JoyconInput.GetRButtonFase(Joycon.Button.SHOULDER_1) == JoyconInput.InputFase.hold) 
        {
            addRotate.y = setSpeed.rotaSpeed.y * rotaSpeedY;
            rotaSpeedY += setSpeed.rotaAccelSpeed * Time.deltaTime;
            rotaSpeedY = rotaSpeedY > setSpeed.rotaMaxSpeed ? setSpeed.rotaMaxSpeed : rotaSpeedY;
        }
        else if(Mathf.Abs(rotaSpeedY) > 0.0001f)
        {
            rotaSpeedY = Mathf.Lerp(rotaSpeedY,0,setSpeed.rotaDeccelSpeed);
            addRotate.y = setSpeed.rotaSpeed.y * rotaSpeedY;
        }
        else
        {
            rotaSpeedY = 0;
        }
        if (addRotate.magnitude > 0.1f)
        {
            transform.Rotate(addRotate);
        }
        
        var newVelocity = transform.forward * speed ;   
        rBody.velocity = newVelocity;
    }

    /// <summary>
    /// アクセルボタンを押したかのブールのゲッターセッター
    /// </summary>
    public bool getset_buttonAccel
    {
        get { return m_buttonAccel; }
        set { m_buttonAccel = value; }
    }
}