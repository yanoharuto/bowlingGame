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
    //��]���x
    [SerializeField] private float setRotaSpeed;
    public float rotaSpeed { get => setRotaSpeed; }
    //������
    [SerializeField] private float setAccelSpeed;
    public float accelSpeed { get => setAccelSpeed; }
    //�ő呬�x
    [SerializeField] private float setMaxSpeed;
    public float maxSpeed { get => setMaxSpeed;}
    //�ő呬�x
    [SerializeField] [Range(1.0f,100.0f)] private float setCorrectionRotate;
    public float correctionRotate { get => setCorrectionRotate; }
}
