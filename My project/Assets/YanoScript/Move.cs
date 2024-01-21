using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Move : MonoBehaviour
{ 
    //�g���K�[�{�^�����������Ƃ���Joycon�̌X���l
    private Quaternion holdStartJVec = Quaternion.identity;
    //�g���K�[�{�^�����������Ȃ�true
    private bool hold = false;
    /// �ړ����x�����W�b�h�{�f�B�ɔ��f
    private Rigidbody rigidbody;
    /// �v���C���[�̊e�푬��
    [SerializeField] private PlayerSpeed setSpeed;
    /// ���񂾂���������茸�������肷��
    private float speed;
    
    /// <summary>
    /// ���W�b�h�{�f�B����
    /// </summary>
    private void Start()
    {
        rigidbody = gameObject.AddComponent<Rigidbody>();
        speed = 0;

    }
    /// <summary>
    /// �����̍X�V
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
    /// �i�s�����Ɍ����Ă��̕����Ɉړ�
    /// </summary>
    private void FixedUpdate()
    {
        var isL = JoyconManager.Instance.j[0].isLeft;
        var lCon = isL ? JoyconManager.Instance.j[0] : JoyconManager.Instance.j[1];
        var rCon = isL ? JoyconManager.Instance.j[1] : JoyconManager.Instance.j[0];
        //�W���C�R���̃X�e�B�b�N�̒l
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