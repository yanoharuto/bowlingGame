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

        if(colorSpeedRota)
        {
            if (clearTimeValue.effectColor.r < 255)
            {
                clearTimeValue.effectColor += Color.HSVToRGB(0.1f, 0.1f, 0.1f);
                bestClearTimeValue.effectColor += Color.HSVToRGB(0.1f, 0.1f, 0.1f);
            }
            if (clearTimeValue.effectColor.r == 255)
            {
                colorSpeedRota = false;
            }
        }
        else
        {
            if(clearTimeValue.effectColor.r > 0) 
            {
                clearTimeValue.effectColor -= Color.HSVToRGB(0.1f, 0.1f, 0.1f);
                bestClearTimeValue.effectColor -= Color.HSVToRGB(0.1f, 0.1f, 0.1f);
            }
            if(clearTimeValue.effectColor.r == 0)
            {
                colorSpeedRota = true;
            }
        }
    }
}
