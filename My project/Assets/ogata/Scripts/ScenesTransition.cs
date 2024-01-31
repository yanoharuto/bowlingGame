using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesTransition : MonoBehaviour
{

    // シーン切り替え用の保存変数
    Dictionary<string, string> ST_Scenes = new Dictionary<string, string>()
    {
        { "タイトル",         "" },
        { "イージー",         "FlightGameScene_Easy" },
        { "スタンダード",     "FlightGameScene_Standard" },
        { "ハード",           "FlightGameScene_Hard" },
        { "リザルト",         "ResultScene" },
        { "ゲームオーバー",    "" },
    };


    /// <summary>
    /// シーン切り替え関数
    /// </summary>
    /// <param name="SceneName">タイトル、ゲームシーン、リザルト、ゲームオーバー</param>
    public void ST_ChangeScenes(string SceneName)
    {
        SceneManager.LoadScene(ST_Scenes[SceneName]);
    }
}
