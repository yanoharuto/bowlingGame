using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    //��]��
    private Vector3 addRotate = Vector3.zero;
    private Vector3 prevE = Vector3.zero;
    //�@�̂̏C��
    private bool isCorrectionRotate = false;
    //�ЂƂO��Joycon�̌X���l
    private Quaternion prevGyro = Quaternion.identity;
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
        //    //��]����
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