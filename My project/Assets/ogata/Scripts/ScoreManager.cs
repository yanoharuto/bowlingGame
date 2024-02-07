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

    void Update()
    {
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
            // スコア更新処理
            if(PlayerPrefs.GetFloat("Score") > PlayerPrefs.GetFloat("BestScore_Easy") ||
                !PlayerPrefs.HasKey("BestScore_Easy"))
            {
                PlayerPrefs.SetFloat("BestScore_Easy", PlayerPrefs.GetFloat("Score"));
                PlayerPrefs.Save();
            }

            return PlayerPrefs.GetFloat("BestScore_Easy");
        }
        else if(SM_Scenes["Standard"] == SceneManager.GetActiveScene().name)
        {
            // スコア更新処理
            if (PlayerPrefs.GetFloat("Score") > PlayerPrefs.GetFloat("BestScore_Standard") ||
                !PlayerPrefs.HasKey("BestScore_Standard"))
            {
                PlayerPrefs.SetFloat("BestScore_Standard", PlayerPrefs.GetFloat("Score"));
                PlayerPrefs.Save();
            }

            return PlayerPrefs.GetFloat("BestScore_Standard");
        }
        else
        {
            // スコア更新処理
            if (PlayerPrefs.GetFloat("Score") < PlayerPrefs.GetFloat("BestScore_Hard") ||
                !PlayerPrefs.HasKey("BestScore_Hard"))
            {
                PlayerPrefs.SetFloat("BestScore_Hard", PlayerPrefs.GetFloat("Score"));
                PlayerPrefs.Save();
            }

            return PlayerPrefs.GetFloat("BestScore_Hard");
        }
    }
}