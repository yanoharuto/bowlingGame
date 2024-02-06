using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Text_Get : MonoBehaviour
{
    ScoreManager tg_ScoreManager;

    [Header("シーン名を表示するテキスト")]
    [SerializeField] TextMeshProUGUI sceneName;
    [Header("クリアタイムを表示するテキスト")]
    [SerializeField] TextMeshProUGUI clearTimeValue;
    [Header("最高クリアタイムを表示するテキスト")]
    [SerializeField] TextMeshProUGUI bestClearTimeValue;

    // Start is called before the first frame update
    void Start()
    {
        tg_ScoreManager = new ScoreManager();

        sceneName.text = tg_ScoreManager.SM_getSceneName();
        clearTimeValue.text = tg_ScoreManager.SM_getCurrentScore().ToString();
        bestClearTimeValue.text = tg_ScoreManager.SM_getBestScore().ToString();
    }

}