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
    /// �����̕ύX�t���O
    /// </summary>
    bool scaleSizeRota = true;

    /// <summary>
    ///
    /// </summary>
    bool colorSpeedRota = true;

    /// <summary>
    /// �ω��l
    /// </summary>
    const float magnificationValue = 0.0025f;

    [Header("�F�ύX�X�p��")]
    public float change_Color_Time = 0.1f;

    [Header("�ύX�̊��炩��")]
    public float Smooth = 0.01f;

    [Header("�F��")]
    [Range(0, 1)] public float HSV_Hue = 1.0f;

    [Header("�ʓx")]
    [Range(0, 1)] public float HSV_Saturation = 1.0f;

    [Header("���x")]
    [Range(0, 1)] public float HSV_Brightness = 1.0f;

    [Header("�F�ʁFMax")]
    [Range(0, 1)] public float HSV_Hue_max = 1.0f;

    [Header("�F�ʁFMin")]
    [Range(0, 1)] public float HSV_Hue_min = 0.0f;


    private void Start()
    {
        HSV_Hue = HSV_Hue_min;

        // �N���A�^�C�����Q�[�~���O�C���R��
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
    /// �j���[���R�[�h�X�V�����Ƃ��ɃN���A�^�C���̃A�E�g���C�����Q�[�~���O�����鏈��
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
