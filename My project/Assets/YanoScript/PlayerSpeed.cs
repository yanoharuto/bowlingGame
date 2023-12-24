using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーの速さ
/// </summary>
[CreateAssetMenu(menuName ="Create/PlayerSpeed",fileName ="playerSpeed")]
public class PlayerSpeed : ScriptableObject
{
    //回転速度
    [SerializeField] private float setRotaSpeed;
    public float rotaSpeed { get => setRotaSpeed; }
    //加速量
    [SerializeField] private float setAccelSpeed;
    public float accelSpeed { get => setAccelSpeed; }
    //最大速度
    [SerializeField] private float setMaxSpeed;
    public float maxSpeed { get => setMaxSpeed;}
}
