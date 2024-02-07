using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTest : MonoBehaviour
{

    public Fade fade;              //フェードキャンバス取得

    // Use this for initialization
    void Start()
    {
        //トランジションを掛けてシーン遷移する
        fade.FadeIn(1f, () =>
        {
        });
    }

    // Update is called once per frame
    void Update()
    {

    }


    //ゲームスタート
    public void StartBt()
    {

    }
}
