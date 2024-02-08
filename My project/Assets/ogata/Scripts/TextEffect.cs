using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    [SerializeField] GameObject newRecode;
    [SerializeField] Outline clearTimeValue;
    [SerializeField] Outline bestClearTimeValue;

    /// <summary>
    /// 加減の変更フラグ
    /// </summary>
    bool scaleSizeRota = true;

    /// <summary>
    ///
    /// </summary>
    bool colorSpeedRota = true;

    /// <summary>
    /// 変化値
    /// </summary>
    const float magnificationValue = 0.0025f;

    [Header("色変更スパン")]
    public float change_Color_Time = 0.1f;

    [Header("変更の滑らかさ")]
    public float Smooth = 0.01f;

    [Header("色彩")]
    [Range(0, 1)] public float HSV_Hue = 1.0f;

    [Header("彩度")]
    [Range(0, 1)] public float HSV_Saturation = 1.0f;

    [Header("明度")]
    [Range(0, 1)] public float HSV_Brightness = 1.0f;

    [Header("色彩：Max")]
    [Range(0, 1)] public float HSV_Hue_max = 1.0f;

    [Header("色彩：Min")]
    [Range(0, 1)] public float HSV_Hue_min = 0.0f;


    private void Start()
    {
        HSV_Hue = HSV_Hue_min;

        // クリアタイムをゲーミングインコか
        StartCoroutine("Change_Color");
    }


    // Update is called once per frame
    void Update()
    {
        if(scaleSizeRota) 
        {
            if (newRecode.gameObject.transform.localScale.x < 0.5005)
            {
                newRecode.gameObject.transform.localScale 
                    +=  new Vector3(magnificationValue,magnificationValue,magnificationValue);
            }
            if (newRecode.gameObject.transform.localScale.x >= 0.5005)
            {
                scaleSizeRota = false;
            }
        }
        else
        {
            if(newRecode.gameObject.transform.localScale.x > 0.25)
            {
                newRecode.gameObject.transform.localScale 
                    -= new Vector3(magnificationValue, magnificationValue, magnificationValue);
            }
            if(newRecode.gameObject.transform.localScale.x <= 0.25)
            {
                scaleSizeRota = true;
            }
        }
    }

    /// <summary>
    /// ニューレコード更新したときにクリアタイムのアウトラインがゲーミング化する処理
    /// </summary>
    /// <returns></returns>
    IEnumerator Change_Color()
    {
        HSV_Hue += Smooth;

        if(HSV_Hue >= HSV_Hue_max)
        {
            HSV_Hue = HSV_Hue_min;
        }

        clearTimeValue.effectColor = Color.HSVToRGB(HSV_Hue, HSV_Saturation, HSV_Brightness);

        yield return new WaitForSeconds(change_Color_Time);

        StartCoroutine("Change_Color");
    }
}
