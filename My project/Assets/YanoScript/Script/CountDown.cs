using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] Text countText;
    [SerializeField] CountDownText texts;
    public bool isEndCountDown { get; private set; }
    private float time;
    private void Update()
    {
        if (PlayFaseManager.nowFase == PlayFaseManager.Fase.countDown)
        {
            time += Time.deltaTime;
            if (time > 5) 
            {
                isEndCountDown = true;
                countText.text = texts.end;
            }
            else if(time > 4)
            {
                countText.text = texts.three;
            }
            else if(time > 3)
            {
                countText.text = texts.two;
            }
            else if(time > 2)
            {
                countText.text = texts.one;
            }
            else
            {
                countText.text = texts.start;
            }
        }
    }
}
