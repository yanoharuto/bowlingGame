using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Get : MonoBehaviour
{
    ScoreManager tg_ScoreManager;

    [Header("シーン名を表示するテキスト")]
    [SerializeField] Text sceneName;
    [Header("クリアタイムを表示するテキスト")]
    [SerializeField] Text clearTimeValue;
    [Header("最高クリアタイムを表示するテキスト")]
    [SerializeField] Text bestClearTimeValue;
    [Header("タイム更新時に表示するテキスト")]
    [SerializeField] GameObject newRecode;


    // Start is called before the first frame update
    void Start()
    {
        tg_ScoreManager = new ScoreManager();

        sceneName.text = tg_ScoreManager.SM_getSceneName();
        clearTimeValue.text = tg_ScoreManager.SM_getCurrentScore().ToString();
        bestClearTimeValue.text = tg_ScoreManager.SM_getBestScore().ToString();

        if(tg_ScoreManager.getset_newRecodeFlag == true)
        {
            newRecode.active = true;
        }
    }

}