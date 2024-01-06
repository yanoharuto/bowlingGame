using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShipCamera : MonoBehaviour
{
    //プレイヤーとの距離
    float betweenSize = -10.0f;
    const float bSizeMax = 30.0f;
    const float bSizeMin = 10.0f;
    //カメラとプレイヤーの距離
    Vector3 flyShipBetween = new Vector3(0,0,0);
    private void Start()
    {
        var playerPos = GameObjectPosition.GetDictionaryObjectPositon("Player");
        flyShipBetween = (playerPos - transform.position).normalized * betweenSize ;
        transform.position = playerPos + flyShipBetween;
        transform.LookAt(playerPos);
    }
    /// <summary>
    /// カメラ更新
    /// </summary>
    private void FixedUpdate()
    {
        //スティックを曲げてるか調べる
        var stick = JoyconManager.Instance.j[0].GetStick();
        var sX = stick[0];
        //プレイヤーとの距離を更新
        if (Mathf.Abs(sX) > 0.1f) 
        {
            var cross = Vector3.Cross(flyShipBetween.normalized, Vector3.up);
            flyShipBetween += sX > 0 ? cross : -cross;
        }
        //プレイヤーの位置に合わせてカメラを回転と移動
        var playerPos = GameObjectPosition.GetDictionaryObjectPositon("Player");
        
        betweenSize = (playerPos - transform.position).magnitude;
        betweenSize = betweenSize < bSizeMin ? bSizeMin : betweenSize;
        betweenSize = betweenSize > bSizeMax ? bSizeMax : betweenSize;
        flyShipBetween = flyShipBetween.normalized * betweenSize;
        transform.position = playerPos + flyShipBetween;
        transform.LookAt(playerPos);
    }
}
