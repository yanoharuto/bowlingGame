using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Create/PlayerSpeed",fileName ="playerSpeed")]
public class PlayerSpeed : ScriptableObject
{
    [SerializeField] private float setRotaSpeed;
    public float rotaSpeed { get => setRotaSpeed; }
    [SerializeField] private float setMoveSpeed;
    public float moveSpeed { get => setMoveSpeed; }
}
