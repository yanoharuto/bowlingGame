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
    [SerializeField][Header("各軸の回転速度")] private Vector3 setRotaSpeed;
    //各軸の回転速度
    public Vector3 rotaSpeed { get => setRotaSpeed; }
    [SerializeField][Header("各軸の回転減速量")] private float setDeccelSpeed;
    //各軸の回転減速量
    public float rotaDeccelSpeed { get => setDeccelSpeed; }
    [SerializeField][Header("各軸の回転加速速度")] private float setRotaAccelSpeed;
    //各軸の回転加速速度
    public float rotaAccelSpeed { get => setRotaAccelSpeed; }
    [SerializeField][Header("各軸の回転最大速度")] private float setRotaMaxSpeed;
    //各軸の回転最大速度
    public float rotaMaxSpeed { get => setRotaMaxSpeed; }
    [SerializeField][Header("減速")] private float setDecelSpeed;
    //減速量
    public float decelSpeed { get => setDecelSpeed; }
    [SerializeField][Header("A入力中の加速倍率")][Range(1.0f,5.0f)] private float setBoostRatio;
    public float boostRaito { get => setBoostRatio; }
    [SerializeField][Header("加速量")] private float setAccelSpeed;
    //加速量
    public float accelSpeed { get => setAccelSpeed; }
    [SerializeField][Header("最大速度")] private float setMaxSpeed;
    //最大速度
    public float maxSpeed { get => setMaxSpeed;}

    [SerializeField][Header("最低速度")] private float setMinSpeed;
    //最低速度
    public float minSpeed { get => setMinSpeed; }
}
