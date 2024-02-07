using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �v���C���[�̑���
/// </summary>
[CreateAssetMenu(menuName ="Create/PlayerSpeed",fileName ="playerSpeed")]
public class PlayerSpeed : ScriptableObject
{
    [SerializeField][Header("�e���̉�]���x")] private Vector3 setRotaSpeed;
    //�e���̉�]���x
    public Vector3 rotaSpeed { get => setRotaSpeed; }
    [SerializeField][Header("�e���̉�]������")] private float setDeccelSpeed;
    //�e���̉�]������
    public float rotaDeccelSpeed { get => setDeccelSpeed; }
    [SerializeField][Header("�e���̉�]�������x")] private float setRotaAccelSpeed;
    //�e���̉�]�������x
    public float rotaAccelSpeed { get => setRotaAccelSpeed; }
    [SerializeField][Header("�e���̉�]�ő呬�x")] private float setRotaMaxSpeed;
    //�e���̉�]�ő呬�x
    public float rotaMaxSpeed { get => setRotaMaxSpeed; }
    [SerializeField][Header("����")] private float setDecelSpeed;
    //������
    public float decelSpeed { get => setDecelSpeed; }
    [SerializeField][Header("A���͒��̉����{��")][Range(1.0f,5.0f)] private float setBoostRatio;
    public float boostRaito { get => setBoostRatio; }
    [SerializeField][Header("������")] private float setAccelSpeed;
    //������
    public float accelSpeed { get => setAccelSpeed; }
    [SerializeField][Header("�ő呬�x")] private float setMaxSpeed;
    //�ő呬�x
    public float maxSpeed { get => setMaxSpeed;}

    [SerializeField][Header("�Œᑬ�x")] private float setMinSpeed;
    //�Œᑬ�x
    public float minSpeed { get => setMinSpeed; }
}
