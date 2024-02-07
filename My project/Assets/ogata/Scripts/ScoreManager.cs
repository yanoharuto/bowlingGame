using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // 経過時間保存変数
    float elapsedTime;

    Dictionary<string, string> SM_Scenes = new Dictionary<string, string>()
    {
        { "Easy",         "FlightGameScene_Easy" },
        { "Standard",     "FlightGameScene_Standard" },
        { "Hard",           "FlightGameScene_Hard" },
    };

    // 新しい記録が出たか
    bool newRecode = false;


    void Update()
    {
        // 時間計測
        elapsedTime += Time.time;
    }

    // シーン切り替え時に呼び出し
    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().name == SM_Scenes["Easy"] ||
            SceneManager.GetActiveScene().name == SM_Scenes["Standard"] ||
            SceneManager.GetActiveScene().name == SM_Scenes["Hard"])
        {
            PlayerPrefs.SetFloat("Score", elapsedTime);
            PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);

            PlayerPrefs.Save();
        }
    }



    /// <returns>プレイしたシーン名</returns>
    public string SM_getSceneName()
    {
        return PlayerPrefs.GetString("SceneName");
    }


    /// <returns>プレイヤーのスコア</returns>
    public float SM_getCurrentScore()
    {
        return PlayerPrefs.GetFloat("Score");
    }


    /// <returns>シーンに応じた最高スコア</returns>
    public float SM_getBestScore()
    {
        // 新状態によって遷移
        if (SM_Scenes["Easy"] == SceneManager.GetActiveScene().name)
        {
            score_Update(SM_Scenes["Easy"]);

            return PlayerPrefs.GetFloat(SM_Scenes["Easy"]);
        }
        else if(SM_Scenes["Standard"] == SceneManager.GetActiveScene().name)
        {
            score_Update(SM_Scenes["Standard"]);

            return PlayerPrefs.GetFloat(SM_Scenes["Standard"]);
        }
        else
        {
            score_Update(SM_Scenes["Hard"]);

            return PlayerPrefs.GetFloat(SM_Scenes["Hard"]);
        }
    }

    /// <summary>
    /// スコア更新処理関数
    /// </summary>
    /// <param name="sceneName">プレイしたシーン名</param>
    void score_Update(string sceneName)
    {
        if (PlayerPrefs.GetFloat("Score") < PlayerPrefs.GetFloat(sceneName) ||
            !PlayerPrefs.HasKey(sceneName))
        {
            newRecode = true;

            PlayerPrefs.SetFloat(sceneName, PlayerPrefs.GetFloat("Score"));
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// new recodeの時にフラグが立つ
    /// </summary>
    public bool getset_newRecodeFlag
    {
        get { return newRecode; }
        set { newRecode = false; }
    }
}