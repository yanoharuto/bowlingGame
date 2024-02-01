using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{

    [SerializeField] GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用

    // マップ用カメラのX軸の固定値
    const float mapCameraRotationX = 90.0f;


    // Use this for initialization
    void Start()
    {
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //新しいトランスフォームの値を代入する
        transform.position = player.transform.position + offset;

        // プレイヤーのY軸の回転度を取得
        float playerRotationY = player.transform.eulerAngles.y;
        // プレイヤーの回転方向を代入。
        transform.localEulerAngles 
            = new Vector3(mapCameraRotationX, playerRotationY, 0.0f);

    }
}