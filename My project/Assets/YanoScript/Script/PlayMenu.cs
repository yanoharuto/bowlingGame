using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour
{
    private float tScale = 0;
    private void Start()
    {
        tScale = Time.timeScale;
    }
    private void Update()
    {
        if(PlayFaseManager.nowFade == PlayFaseManager.Fase.menu)
        { 
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = tScale;
        }
    }
}
