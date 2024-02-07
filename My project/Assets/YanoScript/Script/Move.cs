using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
/// <summary>
/// �ړ��p
/// </summary>
public class Move : MonoBehaviour
{ 
    //�g���K�[�{�^�����������Ƃ���Joycon�̌X���l
    private Quaternion holdStartJVec = Quaternion.identity;
    //�g���K�[�{�^�����������Ȃ�true
    private bool hold = false;
    /// �ړ����x�����W�b�h�{�f�B�ɔ��f
    private Rigidbody rBody;
    /// �v���C���[�̊e�푬��
    [SerializeField] private PlayerSpeed setSpeed;
    /// ���񂾂���������茸�������肷��
    private float speed;
    private float rotaSpeedX;
    private float rotaSpeedY;
    private float rotaSpeedZ;
    /// <summary>
    /// ���W�b�h�{�f�B����
    /// </summary>
    private void Start()
    {
        rBody = gameObject.AddComponent<Rigidbody>();
        speed = setSpeed.minSpeed;
    }
    /// <summary>
    /// �����̍X�V
    /// </summary>
    void Update()
    {
        if (JoyconInput.GetRButtonFase(Joycon.Button.DPAD_DOWN) == JoyconInput.InputFase.hold)
        {
            speed -= setSpeed.decelSpeed * Time.deltaTime;
            if(speed<setSpeed.minSpeed)
            {
                speed = setSpeed.minSpeed;
            }
        }
        else
        {
            if (JoyconInput.GetRButtonFase(Joycon.Button.DPAD_RIGHT) == JoyconInput.InputFase.hold)
            {
                speed += setSpeed.accelSpeed * setSpeed.boostRaito * Time.deltaTime;
            }
            else
            {
                speed += setSpeed.accelSpeed * Time.deltaTime;
            }
            if (speed > setSpeed.maxSpeed)
            {
                speed = setSpeed.maxSpeed;
            }
        }
    }
    /// <summary>
    /// �i�s�����Ɍ����Ă��̕����Ɉړ�
    /// </summary>
    private void FixedUpdate()
    {
        //�W���C�R���̃X�e�B�b�N�̒l
        var sValue = JoyconInput.lJ.GetStick();
        var horizon = sValue[0];
        var vertical = sValue[1];
        var addRotate = Vector3.zero;
       
        if (Mathf.Abs(horizon) > 0.5f)
        {
            addRotate.z = (horizon > 0 ? -setSpeed.rotaSpeed.z : setSpeed.rotaSpeed.z) * rotaSpeedZ;
            rotaSpeedZ += setSpeed.rotaAccelSpeed * Time.deltaTime;
            rotaSpeedZ = rotaSpeedZ > setSpeed.rotaMaxSpeed ? setSpeed.rotaMaxSpeed : rotaSpeedZ;
        }
        else if(rotaSpeedZ > 0)
        {
            rotaSpeedZ = Mathf.Lerp(rotaSpeedZ, 0, setSpeed.rotaDeccelSpeed);
        }
        if (Mathf.Abs(vertical) > 0.5f)
        {
            addRotate.x = (vertical > 0 ? setSpeed.rotaSpeed.x : -setSpeed.rotaSpeed.x) * rotaSpeedX;
            rotaSpeedX += setSpeed.rotaAccelSpeed * Time.deltaTime;
            rotaSpeedX = rotaSpeedX > setSpeed.rotaMaxSpeed ? setSpeed.rotaMaxSpeed : rotaSpeedX;
        }
        else if(rotaSpeedX > 0)
        {
            rotaSpeedX = Mathf.Lerp(rotaSpeedX, 0, setSpeed.rotaDeccelSpeed);
        }
        if (JoyconInput.lJ.GetButton(Joycon.Button.SHOULDER_1)) 
        {
            addRotate.y = -setSpeed.rotaSpeed.y * rotaSpeedY ;
            rotaSpeedY += setSpeed.rotaAccelSpeed * Time.deltaTime;
            rotaSpeedY = rotaSpeedY > setSpeed.rotaMaxSpeed ? setSpeed.rotaMaxSpeed : rotaSpeedY;
        }
        else if( JoyconInput.rJ.GetButton(Joycon.Button.SHOULDER_1))
        {
            addRotate.y = setSpeed.rotaSpeed.y * rotaSpeedY ;
            rotaSpeedY += setSpeed.rotaAccelSpeed * Time.deltaTime;
            rotaSpeedY = rotaSpeedY > setSpeed.rotaMaxSpeed ? setSpeed.rotaMaxSpeed : rotaSpeedY;
        }
        else if(rotaSpeedY > 0)
        {
            rotaSpeedY = Mathf.Lerp(rotaSpeedY,0,setSpeed.rotaDeccelSpeed);
        }
        if (addRotate.magnitude > 0.1f)
        {
            transform.Rotate(addRotate);
        }
        
        var newVelocity = transform.forward * speed ;   
        rBody.velocity = newVelocity;
    }
}