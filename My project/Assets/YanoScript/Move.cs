using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 rotateBack = new Vector3(90,0,0);
    /// �ړ����x�����W�b�h�{�f�B�ɔ��f
    private Rigidbody rigidbody;
    /// <summary>
    /// �v���C���[�̑���
    /// </summary>
    [SerializeField] private PlayerSpeed setSpeed;
    /// <summary>
    /// 
    /// </summary>
    private float speed;
    
    /// <summary>
    /// ���W�b�h�{�f�B����
    /// </summary>
    private void Start()
    {
        rigidbody = gameObject.AddComponent<Rigidbody>();
        speed = 0;
        transform.rotation = JoyconGyroManager.gyroValue;
        transform.Rotate(rotateBack);
    }
    /// <summary>
    /// �i�s�����̍X�V
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
    /// �i�s�����Ɍ����Ă��̕����Ɉړ�
    /// </summary>
    private void FixedUpdate()
    {
        if (JoyconManager.Instance.j[0].GetButton(Joycon.Button.SHOULDER_2))
        {
            transform.Rotate(-rotateBack);
            transform.rotation = Quaternion.Lerp(transform.rotation,JoyconGyroManager.gyroValue,setSpeed.rotaSpeed);
            transform.Rotate(rotateBack);
        }
        rigidbody.velocity = transform.forward * speed;
    }
}