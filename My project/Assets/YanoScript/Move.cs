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
    /// �ړ����x�����W�b�h�{�f�B�ɔ��f
    /// </summary>
    private Rigidbody rigidbody = new Rigidbody();
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
        transform.rotation = JoyconGyroManager.gyroValue;
        transform.Rotate(rotateBack);
        rigidbody.velocity = transform.forward * speed;
    }
}