using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{

    [SerializeField] GameObject player;   //プレイヤー情報格納用

    // oceanのy座標取得
    float oceanPositionY;

    private void Start()
    {
        // Y座標を固定
        oceanPositionY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float playerPositionX = player.transform.position.x;
        float playerPositionZ = player.transform.position.z;

        // プレイヤーについていくように
        this.transform.position 
            = new Vector3(playerPositionX,oceanPositionY,playerPositionZ);
    }
}
