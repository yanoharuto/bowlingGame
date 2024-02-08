using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneChange : MonoBehaviour
{
    [SerializeField] FadeAndLoader fadeIn;
    [SerializeField] Image img;
    private void Update()
    {
        if(img.color.a>0.01f)
        {
            var c = img.color;
            c.a -= 0.1f;
            img.color = c;  
        }
        else if(JoyconInput.GetRButtonFase(Joycon.Button.DPAD_RIGHT)==JoyconInput.InputFase.push)
        {
            StartCoroutine(fadeIn.FadeInAndLoad(img, "TitleScene", 1f)) ;
        }

    }
}
