using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconGyroManager : MonoBehaviour
{
    /// <summary>
    /// 右のジョイコン
    /// </summary>
    static private List<Joycon> joycons;
    /// <summary>
    /// 左のジョイコン
    /// </summary>
    static private Joycon joyconL;
    bool isResetGyroValue = true;
    /// <summary>
    /// Gyroから所得した傾き
    /// </summary>
    static public Quaternion gyroValue { get; private set; } = new Quaternion();
    /// <summary>
    /// 角度増加分
    /// </summary>
    static public Vector3 eulerAngleAddValue { get; private set; } = Vector3.zero;
    private Vector3 firstEulerAngle= Vector3.zero;
    /// <summary>
    /// ジョイコン所得
    /// </summary>
    void Start()
    {
        joycons = JoyconManager.Instance.j;

        if (joycons == null || joycons.Count <= 0) return;

        joyconL = joycons[0];

        gyroValue = joyconL.GetVector();
    }

    /// <summary>
    /// ジョイコンの傾きを保存
    /// </summary>
    void Update()
    {
        var newVector = joyconL.GetVector();
        if (isResetGyroValue)
        {
            firstEulerAngle = newVector.eulerAngles;
            isResetGyroValue = false;
            
        }
        eulerAngleAddValue = newVector.eulerAngles - firstEulerAngle;
        gyroValue = newVector;
    }
}
